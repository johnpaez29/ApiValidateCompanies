using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryCompanies.Models
{
    public class ValidationResponse : IValidationResponse
    {

        [Display(Name = "Nit Empresa")]
        public int Nit { get; set; }

        [Display(Name = "Es valida")]
        public bool isValid { get; set; }

        [Display(Name = "Id de la Razón de invalidez")]
        public long? IdReason { get; set; }

        [Display(Name = "Razón de invalidez")]
        public string Reason { get; set; }

        [Display(Name = "Codigo devuelto")]
        public string Code { get; set; }
    }
}
