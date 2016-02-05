using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VaktarSkipan.BLL.Entities;
using VaktarSkipan.BLL.DB;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class UserController : ApiController
    {
        DatabaseModels dbm = new DatabaseModels();

        [HttpGet]
        public IEnumerable<Vaktir> All()
        {

            var repository = new DatabaseModels();
            return repository.allJobs;
        }
    }
}
