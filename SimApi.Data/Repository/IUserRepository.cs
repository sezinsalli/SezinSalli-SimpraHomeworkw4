using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string name);
    }
}
