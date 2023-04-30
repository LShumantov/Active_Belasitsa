using BelasitsaSkyRun.Umbraco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SkalaTravel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += application_PreRequestHandlerExecute;
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }



        private void application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            try
            {
                if (Session != null && Session.IsNewSession)
                {
                    // Your code here
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bg-BG");
                }
            }
            catch (Exception ex) { }
        }
    }
}