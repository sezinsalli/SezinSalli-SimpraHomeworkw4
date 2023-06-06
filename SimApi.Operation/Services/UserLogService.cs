using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public class UserLogService : IUserLogService
    {
        private readonly IUnitofWork unitOfWork;

        public UserLogService(IUnitofWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Log(string username, string logType)
        {
            UserLog log = new();
            log.LogType = logType;
            log.CreatedAt = DateTime.UtcNow;
            log.TransactionDate = DateTime.UtcNow;
            log.UserName = username;

            unitOfWork.Repository<UserLog>().Insert(log);
            unitOfWork.Complete();
        }
    }
}
