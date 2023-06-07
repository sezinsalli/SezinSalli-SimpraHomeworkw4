using SimApi.Data.Domain;
using SimApi.Operation.Services;
using SimApi.Schema.AccountRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.DapperS
{
    public interface IDapperAccountService : IBaseService<Account, AccountRequest, AccountResponse>
    {
    }
}
