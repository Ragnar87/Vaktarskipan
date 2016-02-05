using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VaktarSkipan.BLL.Entities;

namespace VaktarSkipan.webui.Concrete
{
    public class Authprovider
    {
        DatabaseModels dbm = new DatabaseModels();
        public bool Authenticate(string username, string password)
        {
            bool result = dbm.LoginMethod(username, password);
            if (result)
                FormsAuthentication.SetAuthCookie(username, true);

            return result;

        }
    }
}