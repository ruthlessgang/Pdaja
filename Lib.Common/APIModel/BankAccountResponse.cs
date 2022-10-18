using Lib.Data;
using System.Collections.Generic;

namespace Lib.Common.APIModel
{
    public class BankAccountResponse
    {
        public List<BankAccount> BankAccounts { get; set; }
        public Status Status { get; set; }

        public BankAccountResponse()
        {
            BankAccounts = new List<BankAccount>();
            Status = new Status();
        }
    }
}