using LibraryCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCompanies.DataAccess
{
    public class CompanyValidationRepository : ICompanyData<CompanyValidation>
    {
        private CompanyContext _companyContext;

        public CompanyValidationRepository(CompanyContext companyContext) 
        {
            _companyContext = companyContext;
        }


        public CompanyValidation GetDataById(long id)
        {

            return  _companyContext.companyValidations.FirstOrDefault(company => company.Nit == id);

        }

        public void InsertData(CompanyValidation data)
        {
            throw new NotImplementedException();
        }

    }
}
