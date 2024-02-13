using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv.error
{
    public class KullaniciIpAdress
    {
        public static string KullaniciIpBul()
        {
            var IpAdress=string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                IpAdress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
                IpAdress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                IpAdress = HttpContext.Current.Request.UserHostName;
            return IpAdress;



        }
    }
}