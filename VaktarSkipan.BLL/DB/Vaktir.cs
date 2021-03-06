//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VaktarSkipan.BLL.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VaktarSkipan.BLL.Validators;

    public partial class Vaktir
    {
        public int VaktID { get; set; }
        public string PersonID { get; set; }

        [Required(ErrorMessage = "Please specify a job type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please input date")]
        [DateValidator(ErrorMessage = "Date should be in the future")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Required(ErrorMessage = "Please input start time")]
        [RegularExpression("([0-9]+):([0-5]?[0-9]):([0-5]?[0-9])", ErrorMessage = "Start time should be HH:MM")]
        public System.TimeSpan Start { get; set; }

        [Required(ErrorMessage = "Please input end time")]
        [RegularExpression("([0-9]+):([0-5]?[0-9]):([0-5]?[0-9])", ErrorMessage = "Emd time should be HH:MM")]
        public System.TimeSpan End { get; set; }

        public bool isFree { get; set; }

        public virtual Person Person { get; set; }
    }
}
