using Domain;
using Domain.Comandos;
using Domain.Entidades;
using Domain.Repositorios;
using Domain.Utils;
using Domain.Utils.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ICommandBus CB;
        private IRepositorioAtividadesCtrlQualidade atividades;

        public HomeController(ICommandBus commandBus, IRepositorioAtividadesCtrlQualidade atividades)
        {
            this.CB = commandBus;
            this.atividades = atividades;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Agendar()
        {
            var result = await this.CB.Send(new AgendarNovaACQ
            {
                Local = new Domain.Entidades.Localidade { 
                    ID = 1, 
                    Sigla = "SEDE" 
                },
                Periodo = Periodo.MesCorrente()
            });

            if (result.OK)
            {
                ///*
                var acq = await AgendarNovaACQConcluir(1);

                if (acq != null)
                {
                    //Aqui é recomendado utilizar um RedirectToAction, estou retornando a view diretamente porque meu repositório não possui estado entre requisições
                    return View("AtividadeCQ", acq);
                }
                else
                {
                    TempData["MSG_STATUS"] = "Processamento ainda em andamento...";

                    return View("Index");
                }
            }
            else
                return new HttpStatusCodeResult(500, "Erro durante execução do comando");

            //*/
        }

        private Task<AtividadeCtrlQualidade> AgendarNovaACQConcluir(Int32 id)
        {
            return TimerTaskFactory.StartNew(
                () => this.atividades.Recuperar(id), //ação realizada continuamente
                a => a != null && a.Estado == AtividadeCtrlQualidade.Estados.Agendada, //Valida se deve tentar novamente
                TimeSpan.FromMilliseconds(200), //Intervalo
                TimeSpan.FromMilliseconds(2000)); //Tempo máximo de espera
        }
    }
}