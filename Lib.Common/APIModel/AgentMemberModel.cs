using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lib.Common.APIModel
{
    public class AgentMember
    {
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        public string AccountBankCode { get; set; }
        public string AccountBankName { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string PhoneNo { get; set; }
        public string WorkingTypeCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityQuestionCode { get; set; }
        public string SecurityAnswer { get; set; }
    }

    public class AgentMemberResponse
    {
        public List<AgentMember> Agents { get; set; }
        public Status Status { get; set; }

        public AgentMemberResponse()
        {
            Agents = new List<AgentMember>();
            Status = new Status();
        }
    }
}