using AutoMapper;
using SimApi.Base.Response;
using SimApi.Base.Transaction;
using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using SimApi.Schema.AccountRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public class AccountService : BaseService<Account, AccountRequest, AccountResponse>, IAccountService
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;
        public AccountService(IUnitofWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ApiResponse Balance(int accountId, decimal amount, TransactionDirection direction)
        {
            if (accountId == 0)
            {
                return new ApiResponse("Invalid Account");
            }

            var account = unitOfWork.Repository<Account>().Where(x => x.Id == accountId).FirstOrDefault();
            if (account is null)
            {
                return new ApiResponse("Invalid Account");
            }

            var balance = account.Balance;
            if (direction == TransactionDirection.Deposit)
            {
                balance += amount;
            }
            if (direction == TransactionDirection.Withdraw)
            {
                if (account.Balance < amount)
                {
                    return new ApiResponse("Insufficent balance");
                }

                balance -= amount;
            }

            account.Balance = balance;
            unitOfWork.Repository<Account>().Update(account);
            unitOfWork.Complete();

            return new ApiResponse();
        }

        public ApiResponse<List<AccountResponse>> ByCustomerId(int customerId)
        {
            if (customerId == 0)
                return new ApiResponse<List<AccountResponse>>("Invalid Customer ID");

            try
            {
                var entityList = unitOfWork.Repository<Account>().Where(x => x.CustomerId == customerId).ToList();
                var mapped = mapper.Map<List<Account>, List<AccountResponse>>(entityList);
                return new ApiResponse<List<AccountResponse>>(mapped);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<AccountResponse>>(ex.Message);
            }
        }
    }
}
