using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryCompanies.Models
{
    public class CompanyValidation
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Nit Empresa")]
        public int Nit { get; set; }

        [Display(Name = "Es valida")]
        public bool isValid { get; set; }

        [Display(Name = "Id de la Razón de invalidez")]
        public long? IdReason { get; set; }
    }
}
