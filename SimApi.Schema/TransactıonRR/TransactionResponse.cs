using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.TransactıonRR
{
    public class TransactionResponse : BaseResponse
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public byte Direction { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransactionCode { get; set; }
    }
}
