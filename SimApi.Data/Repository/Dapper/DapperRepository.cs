using SimApi.Base.Model;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository.Dapper
{
    public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
    {
        protected readonly SimDapperDbContext dbContext;
        private bool disposed;
        public DapperRepository()
        {
            this.dbContext = dbContext;
        }
        public void DeleteById(int id)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var query = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public List<Entity> Filter(string sql)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                return connection.Query<Entity>(sql).ToList();
            }
        }

        public List<Entity> GetAll()
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var query = $"SELECT * FROM {GetTableName()}";
                return connection.Query<Entity>(query).ToList();
            }
        }

        public Entity GetById(int id)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var query = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Entity>(query, new { Id = id });
            }
        }

        public void Insert(Entity entity)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var properties = GetEntityProperties(entity);
                var query = $"INSERT INTO {GetTableName()} ({string.Join(", ", properties.Keys)}) " +
                            $"VALUES (@{string.Join(", @", properties.Keys)})";
                connection.Execute(query, entity);
            }
        }

        public void Update(Entity entity)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var properties = GetEntityProperties(entity);
                var updateColumns = properties.Keys.Select(key => $"{key} = @{key}");
                var query = $"UPDATE {GetTableName()} SET {string.Join(", ", updateColumns)} WHERE Id = @Id";
                connection.Execute(query, entity);
            }
        }
        private string GetTableName()
        {
            var tableNameAttribute = typeof(Entity).GetCustomAttributes(typeof(TableNameAttribute), true)
                                                  .FirstOrDefault() as TableNameAttribute;
            return tableNameAttribute?.TableName ?? typeof(Entity).Name;
        }

        private Dictionary<string, object> GetEntityProperties(Entity entity)
        {
            var properties = new Dictionary<string, object>();
            var entityType = entity.GetType();
            var entityProperties = entityType.GetProperties();

            foreach (var property in entityProperties)
            {
                var value = property.GetValue(entity);
                properties[property.Name] = value;
            }

            return properties;
        }
    }
}
