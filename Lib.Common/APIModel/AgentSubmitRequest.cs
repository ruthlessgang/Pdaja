using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class AgentSubmitRequest
    {
        public string AgenID { get; set; }
        public string AgenName { get; set; }
        public string AgenType { get; set; }
        public string Sub_AgenType1 { get; set; }
        public string Sub_AgenType2 { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string NoRek { get; set; }
        public string NamaPemilik { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string NoHp { get; set; }
        public string NoKTP { get; set; }

    }
}
