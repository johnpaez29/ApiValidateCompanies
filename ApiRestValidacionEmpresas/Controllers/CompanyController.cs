using LibraryCompanies.DataAccess;
using LibraryCompanies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestValidacionEmpresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyData<Company> _dataCompany;

        public CompanyController(ICompanyData<Company> dataCompany)
        {
            _dataCompany = dataCompany;
        }
        [HttpPost]
        public IActionResult InsertCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dataCompany.InsertData(company);

                    return Ok(string.Empty);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }

            return BadRequest();
        }
    }
}
