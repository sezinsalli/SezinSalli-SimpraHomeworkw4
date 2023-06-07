using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.TransactıonRR
{
    public class CashRequest : BaseRequest
    {
        public int AccountId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
