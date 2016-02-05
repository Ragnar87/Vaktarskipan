using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.Entities;

namespace VaktarSkipan.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class VaktirController : ApiController
    {

        DatabaseModels dbm = new DatabaseModels();

        [HttpGet]
        public IEnumerable<Vaktir> All()
        {

            
            return dbm.allJobs;
        }
    }
}



