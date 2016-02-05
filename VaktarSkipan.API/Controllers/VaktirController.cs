using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
//using VaktarSkipan.API.Models;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.DTOModels;
using VaktarSkipan.BLL.Entities;

namespace VaktarSkipan.API.Controllers
{
    //[EnableCors("*", "*", "*", SupportsCredentials = true)] 
    public class VaktirController : ApiController
    {
        DatabaseModels dbm = new DatabaseModels();
        [EnableCors("http://localhost:1430", "*", "*", SupportsCredentials = true)] 
        [Authorize]
        [HttpGet]
        public IEnumerable<VaktirDTO> All()
        {
            
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            
            var Vaktir = from v in dbm.allJobs
                         where v.PersonID == LoggedIn.username
                        select new VaktirDTO()
                        {
                            
                            VaktID = v.VaktID,
                            Type = v.Type,
                            Date = v.Date.ToString().Substring(0,10),
                            Start = v.Start,
                            
                            End = v.End


                        };

            return Vaktir;
        }



        /*public VaktirDTO Vakt(int id)
        {
            var Vakt = from v in dbm.allJobs
                       where v.VaktID == id
                       select new VaktirDTO()
                       {
                           VaktID = v.VaktID,
                           Type = v.Type,
                           Date = v.Date,
                           Start = v.Start,
                           End = v.End
                       };

            VaktirDTO returnVakt = new VaktirDTO();
            foreach (var v in Vakt)
            {
                returnVakt.VaktID = v.VaktID;
                returnVakt.Type = v.Type;
                returnVakt.Date = v.Date;

            }

            return returnVakt;

        }*/

        

    }
}
