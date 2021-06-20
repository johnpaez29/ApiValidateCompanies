using LibraryCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCompanies.DataAccess
{
    public class InvalidateReasonRepository : ICompanyData<InvalidateReason>
    {
        private CompanyContext _companyContext;

        public InvalidateReasonRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public InvalidateReason GetDataById(long id)
        {
            return _companyContext.InvalidateReasons.FirstOrDefault(reason => reason.Id == id);
        }

        public void InsertData(InvalidateReason data)
        {
            throw new NotImplementedException();
        }

    }
}
