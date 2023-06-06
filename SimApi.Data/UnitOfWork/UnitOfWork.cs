using SimApi.Base.Model;
using SimApi.Data.Context;
using SimApi.Data.Domain;
using SimApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        public IGenericRepository<Category> CategoryRepository { get; private set; }
        



        private readonly SimDbContext dbContext;        
        private bool disposed;

        public UnitOfWork(SimDbContext dbContext)
        {
            this.dbContext = dbContext;


            CategoryRepository = new GenericRepository<Category>(dbContext);
            
        }
        public IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel
        {
            return new GenericRepository<Entity>(dbContext);
        }

        public void Complete()
        {
            //tek 1 işlem için
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
                if (disposing && dbContext is not null)
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
