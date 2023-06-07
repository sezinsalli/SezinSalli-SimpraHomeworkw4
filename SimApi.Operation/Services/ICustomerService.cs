using SimApi.Data.Domain;
using SimApi.Schema.CustomerRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface ICustomerService : IBaseService<Customer, CustomerRequest, CustomerResponse>
    {
    }
}
