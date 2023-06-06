using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository.Dapper
{
    public interface IDapperRepository<Entity> where Entity : BaseModel
    {
        List<Entity> GetAll();
        List<Entity> Filter(string sql);
        Entity GetById(int id);
        void Insert(Entity entity);
        void Update(Entity entity);
        void DeleteById(int id);
    }
}
