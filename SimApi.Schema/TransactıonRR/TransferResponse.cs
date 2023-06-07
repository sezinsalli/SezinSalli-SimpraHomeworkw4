using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.TransactıonRR
{
    public class TransferResponse : BaseResponse
    {
        public string ReferenceNumber { get; set; }
    }
}
