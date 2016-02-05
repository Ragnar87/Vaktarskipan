using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaktarSkipan.BLL.Entities;
using VaktarSkipan.BLL.DB;
using System.Web.Mvc;

namespace VaktarSkipan.BLL.Entities
{
    public class PeopleJobvm
    {
        public List<Person> ListOfPersons { get; set; }

        public int id { get; set; }
       
        public Vaktir job { get; set; }
        public List<SelectListItem> PersonList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
         
                    foreach(Person pe in ListOfPersons)
                    {
                        list.Add(new SelectListItem
                             {
                                 Value = pe.PersonID.ToString(),
                                 Text = pe.fullName(),
                                 Selected = false
                             });
                             
                       
                    }
          

            return list;
        }
     }
}
