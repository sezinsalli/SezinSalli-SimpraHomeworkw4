using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.TokenRR
{
    public class TokenRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
