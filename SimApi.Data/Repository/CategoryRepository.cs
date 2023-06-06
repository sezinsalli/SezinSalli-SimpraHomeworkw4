using SimApi.Data.Context;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SimDbContext context) : base(context)
        {

        }

        public IEnumerable<Category> FindByName(string name)
        {
            var list = dbContext.Set<Category>().Where(c => c.Name.Contains(name)).ToList();
            return list;
        }

        public int GetAllCount()
        {
            return dbContext.Set<Category>().Count();
        }
    }
}
