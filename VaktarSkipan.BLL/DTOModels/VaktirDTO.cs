using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VaktarSkipan.BLL.DTOModels
{
    public class VaktirDTO
    {
        public int VaktID { get; set; }
        public string PersonID { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public System.TimeSpan Start { get; set; }
        public System.TimeSpan End { get; set; }
        public bool isFree { get; set; }
    }
}
