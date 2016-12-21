using Autofac;
using Autofac.Integration.Mvc;
using Dados;
using Domain.Entidades;
using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using Domain.Utils.Processos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Models;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConfigureDI();
        }

        protected void ConfigureDI()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(
                typeof(AtividadeCtrlQualidade).Assembly, 
                typeof(ICommand).Assembly
            ).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(RepositorioAtividadesCtrlQualidade).Assembly).AsImplementedInterfaces().InstancePerRequest();
           
            builder.RegisterType<AppCommandBus>().As<ICommandBus>().InstancePerRequest();
            builder.RegisterType<AppEventSource>().As<IEventSource>().InstancePerRequest();
            builder.RegisterType<AppProcessManagerContext>().As<IProcessManagerContext>().InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
