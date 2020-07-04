using System;
using Autofac;
using Autofac.Integration.Wcf;

namespace HealthChecks.Wcf.IntegrationTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service1>().As<IService1>();
            builder.RegisterType<MyHealthCheckService>();
            
            var container = builder.Build();

            AutofacHostFactory.Container = container;
            AutofacHostFactory.HostConfigurationAction = HealthCheckExtensions.AddHealthCheckEndpoint();
        }

        

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}