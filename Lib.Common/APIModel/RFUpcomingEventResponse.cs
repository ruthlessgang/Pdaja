using Lib.Common.DataModel;
using System.Collections.Generic;


namespace Lib.Common.APIModel
{
    public class RFUpcomingEventResponse
    {
        public Status Status { get; set; }
        public List<RFUpcomingEventModels> ListRFUpcomingEventModels { get; set; }

        public RFUpcomingEventResponse()
        {
            ListRFUpcomingEventModels = new List<RFUpcomingEventModels>();
            Status = new Status();
        }
    }
}
