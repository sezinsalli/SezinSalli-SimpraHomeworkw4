using SimApi.Base.Response;
using SimApi.Schema.TransactıonRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface ITransactionService
    {
        ApiResponse<List<TransactionResponse>> GetAll();
        ApiResponse<TransactionResponse> GetById(int id);
        ApiResponse<List<TransactionResponse>> GetByParameter(int accountId, int customerId, decimal amount, string description);
        ApiResponse<List<TransactionResponse>> GetByReference(string referenceNumber);
        ApiResponse<TransferResponse> Transfer(TransferRequest request);
        ApiResponse<CashResponse> Deposit(CashRequest request);
        ApiResponse<CashResponse> Withdraw(CashRequest request);
    }
}
