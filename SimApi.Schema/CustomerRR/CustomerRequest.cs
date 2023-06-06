using SimApi.Base.Model;
using SimApi.Schema.AccountRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.CustomerRR
{
    public class CustomerRequest : BaseRequest
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<AccountRequest> Accounts { get; set; } = new List<AccountRequest>();
    }
}
