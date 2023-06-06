using SimApi.Data.Domain;
using SimApi.Schema.UserRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface IUserService : IBaseService<User, UserRequest, UserResponse>
    {
    }
}
