using SimApi.Base.Model;
using SimApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel

    {
        protected readonly SimDbContext dbContext;
        public GenericRepository(SimDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            dbContext.Set<Entity>().Remove(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }

        public List<Entity> GetAllAsNoTracking()
        {
            return dbContext.Set<Entity>().AsNoTracking().ToList();
        }
        public Entity GetById(int id)
        {
            return dbContext.Set<Entity>().Find(id);
        }

        public Entity GetByIdAsNoTracking(int id)
        {
            return dbContext.Set<Entity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Entity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = "sim@sim.com";

            dbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            dbContext.Set<Entity>().Update(entity);
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
        {
            return dbContext.Set<Entity>().Where(expression).AsQueryable();
        }
    }
}
