using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Base.Transaction
{
    public class TransactionCode
    {
        public const string TransferToMyself = "TRANSF";
        public const string TransferToOthers = "TRANSOT";
        public const string Deposit = "DEPOSIT";
        public const string Withdraw = "WITHDRW";
    }
}
