﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base.Response;
using SimApi.Operation.Services;
using SimApi.Schema.AccountRR;
using System.Collections.Generic;

namespace SimApi.sDersNotarı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }


        [HttpGet]
        public ApiResponse<List<AccountResponse>> GetAll()
        {
            var accountList = accountService.GetAll();
            return accountList;
        }

        [HttpGet("{id}")]
        public ApiResponse<AccountResponse> GetById(int id)
        {
            var account = accountService.GetById(id);
            return account;
        }

        [HttpGet("ByCustomerId/{customerId}")]
        public ApiResponse<List<AccountResponse>> ByCustomerId(int customerId)
        {
            var account = accountService.ByCustomerId(customerId);
            return account;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] AccountRequest request)
        {
            return accountService.Insert(request);
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] AccountRequest request)
        {
            return accountService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return accountService.Delete(id);
        }
    }
}
