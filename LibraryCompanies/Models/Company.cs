using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryCompanies.Models
{
    public class Company
    {
        [Key]
        public long? Id { get; set; }

        [Display(Name = "Tipo de Identificación")]
        public string IdentificationType { get; set; }

        [Display(Name = "Numero de Identificación")]
        public int IdentificationNumber { get; set; }

        [Display(Name = "Nombre Empresa")]
        public string CompanyName { get; set; }

        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SecondName { get; set; }

        [Display(Name = "Primer Apellido")]
        public string FirstLastName { get; set; }
    }
}
