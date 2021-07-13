using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.API.DTOs;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Models;

namespace Transaction.API.Controllers
{

    public class TransactionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("AddTransaction")]
        public async Task<ActionResult> AddTransaction([FromBody] Transactions transaction)
        {

            try
            {

                _unitOfWork.TransactionRepository.Add(transaction);
                if (await _unitOfWork.Complete())
                    return Ok(transaction);
                return BadRequest("Error adding customer");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ListTransactions")]
        public async Task<ActionResult> ListAllTransactions()
        {

            try
            {

                var transactions = await _unitOfWork.TransactionRepository.ListAllAsync();
                var transactionsToList = _mapper.Map<IEnumerable<TransactionWithTypeDto>>(transactions);
                return Ok(transactionsToList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public async Task<ActionResult<Transactions>> GetTransaction(int id)
        {
            try
            {
                var transactions = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
                if (transactions == null)
                    return NotFound();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<ActionResult> UpdateTransaction(Transactions transaction)
        {

            try
            {
                _unitOfWork.TransactionRepository.Update(transaction);
                var result = await _unitOfWork.Complete();

                if (result)
                    return NoContent();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [Route("DeleteTransaction/{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            try
            {
                var searchedTransaction = _unitOfWork.TransactionRepository.GetByIdAsync(id);

                if (searchedTransaction.Result == null)
                    return NotFound();

                _unitOfWork.TransactionRepository.Delete(id);
                if (await _unitOfWork.Complete())
                    return Ok();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



    }
}
