using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaktarSkipan.BLL.DB;

namespace VaktarSkipan.webui.ExtendedAttributes
{
    public class AdminCheck : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return LoggedIn.username.Equals("Admin");
        }
    }
}