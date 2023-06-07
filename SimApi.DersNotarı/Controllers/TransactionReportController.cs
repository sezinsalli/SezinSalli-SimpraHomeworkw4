using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base.AttributeR;
using SimApi.Base.Response;
using SimApi.Operation.Services;
using SimApi.Schema.TransactıonRR;
using System.Collections.Generic;

namespace SimApi.sDersNotarı.Controllers
{
    [EnableMiddlewareLogger]
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class TransactionReportController : ControllerBase
    {
        private readonly ITransactionReportService transactionReportService;
        public TransactionReportController(ITransactionReportService transactionReportService)
        {
            this.transactionReportService = transactionReportService;
        }

        [HttpGet]
        public ApiResponse<List<TransactionViewResponse>> GetAll()
        {
            var transactionList = transactionReportService.GetAll();
            return transactionList;
        }

        [HttpGet("{id}")]
        public ApiResponse<TransactionViewResponse> GetById([FromRoute] int id)
        {
            var transaction = transactionReportService.GetById(id);
            return transaction;
        }

        [HttpGet("ByReferenceNumber/{ReferenceNumber}")]
        public ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber([FromRoute] string ReferenceNumber)
        {
            var transactions = transactionReportService.GetByReferenceNumber(ReferenceNumber);
            return transactions;
        }

        [HttpGet("ByAccountId/{AccountId}")]
        public ApiResponse<List<TransactionViewResponse>> GetByAccountId([FromRoute] int AccountId)
        {
            var transactions = transactionReportService.GetByAccountId(AccountId);
            return transactions;
        }


        [HttpGet("ByCustomerId/{CustomerId}")]
        public ApiResponse<List<TransactionViewResponse>> GetByCustomerId([FromRoute] int CustomerId)
        {
            var transactions = transactionReportService.GetByCustomerId(CustomerId);
            return transactions;
        }
    }
}
