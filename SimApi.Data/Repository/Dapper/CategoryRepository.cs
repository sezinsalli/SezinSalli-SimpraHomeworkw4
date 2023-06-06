using SimApi.Data.Context;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository.Dapper
{
    public class CategoryRepository : DapperRepository<Category>, ICategoryRepository
    {
        private readonly SimDapperDbContext simDapperDbContext;

        public CategoryRepository(SimDapperDbContext simDapperDbContext) : base(simDapperDbContext)
        {
            this.simDapperDbContext = simDapperDbContext;
        }
    }

}
