using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class AgentLogin
    {
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }

    public class AgentLoginResponse
    {
        public AgentLogin Agent { get; set; }
        public Status Status { get; set; }

        public AgentLoginResponse()
        {
            Agent = new AgentLogin();
            Status = new Status();
        }
    }
}
