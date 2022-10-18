using Lib.Common.DataModel;
using System.Collections.Generic;


namespace Lib.Common.APIModel
{
    public class RFStatisticResponse
    {
        public Status Status { get; set; }
        public List<RFStatisticModels> ListStatisticModels { get; set; }

        public RFStatisticResponse()
        {
            ListStatisticModels = new List<RFStatisticModels>();
            Status = new Status();
        }
    }
}
