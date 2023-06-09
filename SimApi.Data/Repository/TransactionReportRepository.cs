using SimApi.Data.Context;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository
{
    public class TransactionReportRepository : ITransactionReportRepository
    {
        protected readonly SimDbContext dbContext;
        public TransactionReportRepository(SimDbContext context) 
        {
            this.dbContext = context;
        }
        public List<TransactionView> GetAll()
        {
            return dbContext.TransactionView.ToList();
        }

        public List<TransactionView> GetByAccountId(int accountId)
        {
            return dbContext.TransactionView.Where(t => t.AccountId == accountId).ToList();
        }

        public List<TransactionView> GetByCustomerId(int customerId)
        {
            return dbContext.TransactionView.Where(t => t.CustomerId == customerId).ToList();
        }

        public TransactionView GetById(int id)
        {
            return dbContext.TransactionView.FirstOrDefault(t => t.Id == id);
        }

        public List<TransactionView> GetByReferenceNumber(string referenceNumber)
        {
            return dbContext.TransactionView.Where(t => t.ReferenceNumber == referenceNumber).ToList();
        }
    }
}
