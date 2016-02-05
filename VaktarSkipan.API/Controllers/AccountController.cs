using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;
using VaktarSkipan.API.Infrastructure.Concrete;
//using VaktarSkipan.API.Models;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.Entities;

namespace VaktarSkipan.API.Controllers
{
    //[EnableCors("*", "*", "*")] 
    public class AccountController : ApiController
    {

        DatabaseModels dbm = new DatabaseModels();
        FormsAuthProvider fAuth = new FormsAuthProvider();

        [HttpPost]
        public bool Login(LoginViewModel model)
        {

            if (fAuth.Authenticate(model.UserName, model.Password))
            {
                LoggedIn.username = model.UserName;
                return true;
            }
            else
                return false;

            
        }

        
    }
}
