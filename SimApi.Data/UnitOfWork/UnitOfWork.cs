using SimApi.Base.Model;
using SimApi.Data.Context;
using SimApi.Data.Domain;
using SimApi.Data.Repository;
using SimApi.Data.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly SimDbContext dbContext;
        private readonly SimDapperDbContext dapperDbContext;
        private bool disposed;

        public IDapperRepository<Account> DapperAccountRepository { get; private set; }

        public ITransactionReportRepository TransactionReportRepository { get; private set; }

        public UnitOfWork(SimDbContext dbContext, SimDapperDbContext dapperDbContex)
        {
            this.dbContext = dbContext;
            this.dapperDbContext = dapperDbContex;

            DapperAccountRepository = new DapperAccountRepository(dapperDbContext);
            TransactionReportRepository = new TransactionReportRepository(dbContext);

        }

        public IDapperRepository<Entity> DapperRepository<Entity>() where Entity : BaseModel
        {
            return new DapperRepository<Entity>(dapperDbContext);
        }

        public IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel
        {
            return new GenericRepository<Entity>(dbContext);
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
