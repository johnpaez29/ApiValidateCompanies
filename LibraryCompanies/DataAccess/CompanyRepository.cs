using LibraryCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCompanies.DataAccess
{
    public class CompanyRepository : ICompanyData<Company>
    {
        private CompanyContext _companyContext;

        public CompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public Company GetDataById(long id)
        {
            throw new NotImplementedException();
        }

        public void InsertData(Company data)
        {
            if (data != null && data.IdentificationNumber != 0) 
            {
                var company = _companyContext.Companies.Where(company => company.IdentificationNumber != null && 
                                                                    company.IdentificationType != null &&
                                                                    company.IdentificationNumber == data.IdentificationNumber &&
                                                                    company.IdentificationType.Equals(data.IdentificationType)).FirstOrDefault();

                if (company != null)
                {
                    Update(data, company);
                }
                else
                {
                    Insert(data);

                }

                _companyContext.SaveChanges();
            }
        }

        private void Insert(Company data)
        {
            data.Id = null;
            _companyContext.Companies.Add(data);
        }

        private void Update(Company data, Company company)
        {
            data.Id = company.Id;
            _companyContext.Entry(company).CurrentValues.SetValues(data);
        }
    }
}
