using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class ReqAppStatus
    {
        public string NoRef { get; set; }
        public string NamaLengkap { get; set; }
        public string JumlahPengajuan { get; set; }
        public string JangkaWaktu { get; set; }
        public string TanggalPengajuan { get; set; }
        public string StatusAplikasi { get; set; }
    }
}
