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
    public class ValidatorController : ControllerBase
    {
        private readonly ICompanyData<CompanyValidation> _dataValidation;
        private readonly ICompanyData<InvalidateReason> _dataReason;
        private readonly IValidationResponse _validationResponse;

        public ValidatorController(ICompanyData<CompanyValidation> dataValidation, ICompanyData<InvalidateReason> dataReason, IValidationResponse validationResponse)
        {
            _dataValidation = dataValidation;
            _dataReason = dataReason;
            _validationResponse = validationResponse;
        }

        [HttpGet("{id}")]
        public IValidationResponse ValidateCompany(long id)
        {
            if (id != 0)
            {
                try
                {
                    CompanyValidation validation = _dataValidation.GetDataById(id);
                    if (validation == null)
                    {
                        _validationResponse.Code = "1";
                        _validationResponse.isValid = false;
                        _validationResponse.Reason = "No se encontró identificación de la empresa por lo que no se valida";

                        return _validationResponse;
                    }

                    if (!validation.isValid)
                    {
                        InvalidateReason reason = _dataReason.GetDataById(validation.IdReason ?? 0);
                        _validationResponse.Code = "1";
                        _validationResponse.isValid = false;
                        _validationResponse.Reason = reason.Reason;

                        return _validationResponse;
                    }

                    _validationResponse.Code = "0";
                    _validationResponse.isValid = validation.isValid;
                    _validationResponse.Reason = null;

                    return _validationResponse;
                }
                catch (Exception e)
                {
                    _validationResponse.Code = "1";
                    _validationResponse.isValid = false;
                    _validationResponse.Reason = e.Message;

                    return _validationResponse;
                }
            }

            _validationResponse.Code = "1";
            _validationResponse.isValid = false;
            _validationResponse.Reason = "Parametros de envío no correctos";

            return _validationResponse;
        }

    }
}
