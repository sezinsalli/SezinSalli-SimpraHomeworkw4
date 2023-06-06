﻿using SimApi.Base.Model;
using SimApi.Schema.AccountRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.CustomerRR
{
    public class CustomerResponse : BaseResponse
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsValid { get; set; }

        public List<AccountResponse> Accounts { get; set; }
    }
}
