using cv.error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace cv
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                LogInfo log = new LogInfo
                {
                    Url = Request.Url.ToString(),
                    HataMesaji = httpException.Message,
                    EklenmeTarihi = DateTime.Now,
                    Ip = KullaniciIpAdress.KullaniciIpBul(),
                    Tarayici = Request.Browser.Browser,
                    Dil = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2)
                };

                switch (httpException.GetHttpCode())
                {
                    case 403:
                        Response.Redirect("/Default/Page403");
                        break;
                    case 404:
                        Response.Redirect("/Default/Page404");
                        break;
                    case 500:
                        Response.Redirect("/Default/Page500");
                        break;
                    default:
                        Response.Redirect("/Default/Page404");
                        break;




                }
                Server.ClearError();


            }
        }
    }
}
