using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.DTOModels;
using VaktarSkipan.BLL.Entities;

namespace VaktarSkipan.API.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")] 
    public class FreeController : ApiController
    {
        DatabaseModels dbm = new DatabaseModels();
        //[Authorize]
        [HttpGet]
        public IEnumerable<VaktirDTO> Free()
        {

            var LeysarVaktir = from v in dbm.allJobs
                               where v.isFree == true
                               select new VaktirDTO()
                               {
                                   VaktID = v.VaktID,
                                   Type = v.Type,
                                   Date = v.Date.ToString().Substring(0,10),
                                   Start = v.Start,
                                   End = v.End
                               };
            return LeysarVaktir;


        }

        //[Authorize]
        [HttpPost]
        public void take(VaktirDTO vakt)
        {
            Vaktir Vakt = dbm.allJobs.FirstOrDefault(v => v.VaktID == vakt.VaktID);

            dbm.takeJob(Vakt);




        }
    }
}
