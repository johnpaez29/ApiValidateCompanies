using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCompanies.DataAccess
{
    public interface ICompanyData<T>
    {
        T GetDataById(long id);
        
        void InsertData(T data);

    }
}
