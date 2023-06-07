﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base.Attribute;
using SimApi.Base.Response;
using SimApi.Operation.Services;
using SimApi.Schema.CustomerRR;
using System.Collections.Generic;

namespace SimApi.sDersNotarı.Controllers
{
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public ApiResponse<List<CustomerResponse>> GetAll()
        {
            var customerList = customerService.GetAll();
            return customerList;
        }

        [HttpGet("{id}")]
        public ApiResponse<CustomerResponse> GetById(int id)
        {
            var customer = customerService.GetById(id);
            return customer;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] CustomerRequest request)
        {
            return customerService.Insert(request);
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] CustomerRequest request)
        {
            return customerService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return customerService.Delete(id);
        }
    }
}
