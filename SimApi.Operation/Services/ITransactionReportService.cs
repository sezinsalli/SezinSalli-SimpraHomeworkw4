using SimApi.Base.Response;
using SimApi.Schema.TransactıonRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface ITransactionReportService
    {
        ApiResponse<List<TransactionViewResponse>> GetAll();
        ApiResponse<TransactionViewResponse> GetById(int id);
        ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber(string referenceNumber);
        ApiResponse<List<TransactionViewResponse>> GetByCustomerId(int customerId);
        ApiResponse<List<TransactionViewResponse>> GetByAccountId(int accountId);
    }
}
