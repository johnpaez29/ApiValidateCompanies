using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryCompanies.Models
{
    public class InvalidateReason
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Razón de la invalidez")]
        public string Reason { get; set; }
    }
}
