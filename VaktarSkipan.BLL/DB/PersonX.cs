using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaktarSkipan.BLL.DB
{
    public partial class Person
    {
        public string fullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
