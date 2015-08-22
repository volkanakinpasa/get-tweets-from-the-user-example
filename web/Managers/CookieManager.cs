using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace web.Managers
{
    public class CookieManager
    {
        private static HttpCookieCollection CookiesRequest
        {
            get
            {
                return HttpContext.Current.Request.Cookies;
            }
        }
     
        private static HttpCookieCollection CookiesResponse
        {
            get
            {
                HttpContext.Current.Response.Buffer = true;
                return HttpContext.Current.Response.Cookies;
            }
        }


        public static void WriteCookie(string cookieName, Dictionary<string, object> values)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Expires = DateTime.Now.AddDays(7),
                Path = "/"
            };

            if (values != null)
            {
                foreach (KeyValuePair<string, object> value in values)
                {
                    cookie.Values.Add(value.Key, Convert.ToString(value.Value));
                }
            }
            CookiesResponse.Add(cookie);
        }

        public static NameValueCollection GetCookieValues(string cookieName)
        {
            HttpCookie userCookie = CookiesRequest.Get(cookieName);
            if (userCookie != null)
            {
                return userCookie.Values;
            }
            return null;
        }

        


    }
}

