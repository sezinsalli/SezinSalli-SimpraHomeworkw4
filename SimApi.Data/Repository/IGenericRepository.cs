using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public interface IGenericRepository<Entity> where Entity : BaseModel
    {
        Entity GetById(int id);
        void Insert(Entity entity);
        void Update(Entity entity);
        void DeleteById(int id);
        void Delete(Entity entity);
        List<Entity> GetAll();
        List<Entity> GetAllAsNoTracking();
        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression);
        Entity GetByIdAsNoTracking(int id);
    }
}
