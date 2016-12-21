using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Eventos;
using Domain.Processos;
using Domain.Comandos;
using Domain.Entidades;
using Domain;
using Moq;
using System.Linq;
using Domain.Repositorios;
using System.Threading.Tasks;
using Domain.Utils.Eventos;
using Domain.Utils.Comandos;
using Domain.Utils;
using Domain.Utils.Processos;
using System.Security.Principal;
using Domain.Servicos;

namespace Tests
{
    [TestClass]
    public class ProcessoElaboracaoACQTests
    {
        private static EventSourcePadrao ES;
        private static CommandBusPadrao CBus;

        [ClassInitialize]
        public static void Init(TestContext ctx)
        {
            ES = new EventSourcePadrao();
            CBus = new CommandBusPadrao();
        }

        [TestMethod]
        public async Task TesteInfraestruturaEventos()
        {
            //
            //Mocks
            //

            var id = (int)DateTime.Now.Ticks;
            var ativResult = new AtividadeCtrlQualidade { ID = id, Estado = AtividadeCtrlQualidade.Estados.Agendada };

            var repo = new Mock<IRepositorioAtividadesCtrlQualidade>();
            repo.Setup(
                x => x.Adicionar(It.IsAny<AtividadeCtrlQualidade>()))
                .Callback<AtividadeCtrlQualidade>(x => x.ID = id)
                .Returns(true);
            repo.Setup(x => x.Recuperar(It.IsAny<Int32>())).Returns(ativResult);

            //
            //Registrando gestor de processos para escutar eventos e processar comandos
            //
                        
            var ctx = new ProcessManagerContextPadrao { CommandBus = CBus, Events = ES, User = null };
            var gpe = new AgendarNovaACQHandler(ES, repo.Object);
            var notificacoes = new ServicoNotificacao();

            await CBus.Register(gpe);
            await ES.Subscribe<Domain.Eventos.EventoAgendamentoNovaACQ>(notificacoes);
            
            //
            //Enviando comando:
            //

            //Action
            //public ActionResult CriarAtividade(ComandoAgendarNovaACQ args) { }
            
            var result = await CBus.Send(new AgendarNovaACQ
            {
                Local = new Localidade { ID = 1, Sigla = "SEDE" },
                Periodo = Periodo.MesCorrente()
            });

            Assert.IsTrue(result.OK);

            //
            //Executa tarefa continuamente determinado pelo intervalo e limites informados
            //

            var ativ = await TimerTaskFactory.StartNew(
                () => repo.Object.Recuperar(id), //ação realizada continuamente
                a => a != null && a.Estado == AtividadeCtrlQualidade.Estados.Agendada, //Valida se deve tentar novamente
                TimeSpan.FromMilliseconds(200), //Intervalo
                TimeSpan.FromSeconds(2)); //Tempo máximo de espera

            Assert.AreEqual(ativ.Estado, AtividadeCtrlQualidade.Estados.Agendada);

            Assert.IsTrue(notificacoes.Historico.Count() == 1);
        }
    }
}
