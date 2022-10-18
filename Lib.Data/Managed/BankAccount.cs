using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class BankAccount
    {
        
        public static IQueryable<BankAccount> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.BankAccounts
                .Where(x => x.IsActive);
        }
    }
}
