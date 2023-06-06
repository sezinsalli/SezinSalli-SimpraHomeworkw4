using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.AccountRR
{
    public class AccountRequest : BaseRequest
    {
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Balance { get; set; }
    }
}
