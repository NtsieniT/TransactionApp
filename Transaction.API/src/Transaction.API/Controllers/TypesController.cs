using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Models.Lookups;

namespace Transaction.API.Controllers
{

    public class TypesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetTransactionTypes")]
        public async Task<ActionResult<TypeLookup>> ListAllCustomers()
        {
            try
            {
                var types = await _unitOfWork.TypeRepository.ListAllAsync();
                return Ok(types);
            }
            catch (Exception ex)
            {

                //replace with logger
                return BadRequest(ex.Message);
            }

        }
    }
}
