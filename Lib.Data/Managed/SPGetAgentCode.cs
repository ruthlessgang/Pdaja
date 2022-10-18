using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class NewAgentCode
    {
        public static string GetNewAgentCode(string BankCode, string Source)
        {
            return DataRepositoryFactory.CurrentRepository.SP_Get_NewAgentCode(BankCode, Source).First();
        }
    }
}
