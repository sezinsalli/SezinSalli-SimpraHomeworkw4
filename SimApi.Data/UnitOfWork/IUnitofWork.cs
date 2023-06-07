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
    public interface IUnitofWork : IDisposable
    {
        IDapperRepository<Account> DapperAccountRepository { get; }
        IDapperRepository<Entity> DapperRepository<Entity>() where Entity : BaseModel;
        IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;


        ITransactionReportRepository TransactionReportRepository { get; }


        void Complete();
        void CompleteWithTransaction();


    }
}
