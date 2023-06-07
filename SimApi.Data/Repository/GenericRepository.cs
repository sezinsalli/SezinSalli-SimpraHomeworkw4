﻿using SimApi.Base.Model;
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
        private bool disposed;

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
            //AsNoTracking() metodu, sorgulanan verilerin değişiklik izlemesini devre dışı bırakır. Bu, performansı artırabilir, ancak dikkatli kullanılmalıdır. Eğer bu metot kullanılmazsa, sorgulanan öğeler değiştirilebilir ve bunlar kaydedilebilir.
            return dbContext.Set<Entity>().AsNoTracking().ToList();
        }
        public List<Entity> GetAllWithInclude(params string[] includes)
        {
            var query = dbContext.Set<Entity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }
        public Entity GetByIdWithInclude(int id, params string[] includes)
        {
            var query = dbContext.Set<Entity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Entity> WhereWithInclude(Expression<Func<Entity, bool>> expression, params string[] includes)
        {
            var query = dbContext.Set<Entity>().AsQueryable();
            query.Where(expression);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
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
        public IEnumerable<Entity> WhereAsNoTracking(Expression<Func<Entity, bool>> expression)
        {
            return dbContext.Set<Entity>().AsNoTracking().Where(expression).AsQueryable();
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbDcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging
                    dbDcontextTransaction.Rollback();
                }
            }
        }


        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }


    }
}
