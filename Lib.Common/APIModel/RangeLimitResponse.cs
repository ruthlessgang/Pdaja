using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class RangeLimitResponse
    {
        public string IdCust { get; set; }
        public string WordingPRK { get; set; }
        public bool hidePA { get; set; }
        public bool hidePRK { get; set; }
        public int MaxTenor { get; set; }
        public Guid Guid_LogLDML { get; set; }
        public List<RangeLimit> ListDataRangeLimit { get; set; }
        public GroupBungaPinjamanByTenorModel[] ArrayDataBungaPinjaman { get; set; }
    }
}
