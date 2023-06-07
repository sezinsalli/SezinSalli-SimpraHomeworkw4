using SimApi.Base.Response;
using SimApi.Base.Transaction;
using SimApi.Data.Domain;
using SimApi.Schema.AccountRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface IAccountService : IBaseService<Account, AccountRequest, AccountResponse>
    {
        ApiResponse<List<AccountResponse>> ByCustomerId(int customerId);
        ApiResponse Balance(int accountId, decimal amount, TransactionDirection direction);
    }
}
