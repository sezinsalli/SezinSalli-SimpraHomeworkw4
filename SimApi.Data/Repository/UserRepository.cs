using SimApi.Data.Context;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SimDbContext context) : base(context)
        {

        }
        public User GetByUsername(string name)
        {
            return dbContext.Set<User>().Where(x => x.UserName == name).FirstOrDefault();
        }
    }
}
