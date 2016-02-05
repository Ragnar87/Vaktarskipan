using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VaktarSkipan.BLL.Validators
{
    class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is DateTime && ((DateTime)value) > DateTime.Today;
        }

    }
}
