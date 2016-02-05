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
    public class VaktController : ApiController
    {
        DatabaseModels dbm = new DatabaseModels();

        [HttpGet]
        public VaktirDTO Vakt(int? id)
        {
            var Vakt = from v in dbm.allJobs
                       where v.VaktID == id
                       select new VaktirDTO()
                       {
                           VaktID = v.VaktID,
                           Type = v.Type,
                           Date = v.Date.ToString().Substring(0,10),
                           Start = v.Start,
                           End = v.End
                       };

            VaktirDTO returnVakt = new VaktirDTO();
            foreach (var v in Vakt)
            {
                returnVakt.VaktID = v.VaktID;
                returnVakt.Type = v.Type;
                returnVakt.Date = v.Date;
                returnVakt.Start = v.Start;
                returnVakt.End = v.End;


            }

            return returnVakt;

        }


        [HttpPost]
        public void release(VaktirDTO vakt)
        {
            Vaktir Vakt = dbm.allJobs.FirstOrDefault(v => v.VaktID == vakt.VaktID);

            dbm.releaseJob(Vakt);




        }
    }
}
