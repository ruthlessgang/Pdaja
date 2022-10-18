using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lib.Common.APIModel
{
    public class AgentRequest
    {
        [JsonProperty("Refferal")]
        public string AgentCode { get; set; }
        [JsonProperty("ReffName")]
        public string AgentName { get; set; }
        public string Status_Post { get; set; }
        public bool IsActive { get; set; }
        [JsonProperty("SourceCode")]
        public string Source { get; set; }
    }

    public class AgentResponse
    {
        public List<AgentRequest> Agent { get; set; }
        public Status Status { get; set; }

        public AgentResponse()
        {
            Agent = new List<AgentRequest>();
            Status = new Status();
        }
    }
}