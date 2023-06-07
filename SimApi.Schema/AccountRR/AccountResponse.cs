using SimApi.Base.Model;
using SimApi.Schema.TransactıonRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.AccountRR
{
    public class AccountResponse : BaseResponse
    {
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Balance { get; set; }
        public bool IsValid { get; set; }

        public List<TransactionResponse> Transactions { get; set; }
    }
}
