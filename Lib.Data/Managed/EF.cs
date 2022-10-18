using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public static partial class EF
    {
        public static int Execute(string SQL)
        {
            int rs = DataRepositoryFactory.CurrentRepository.ExecuteStoreCommand(SQL);

            return rs;
        }
    }
}
