using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VaktarSkipan.webui.Infrastructure.Abstract;

namespace VaktarSkipan.webui.Infrastructure.Concrete
{
    public class FormsAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = false;
           // bool result = FormsAuthentication.Authenticate(username,password);
            if(username == "admin" && password =="admin")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                result = true;
            }

            return result;
        }
    }
}