using Lib.Common.DataModel;
using System.Collections.Generic;


namespace Lib.Common.APIModel
{
    public class RFSpotContestResponse
    {
        public Status Status { get; set; }
        public List<RFSpotContestModels> ListRFSpotContestModels { get; set; }

        public RFSpotContestModels LastDataRFSpotContestModels { get; set; }

        public RFSpotContestResponse()
        {
            ListRFSpotContestModels = new List<RFSpotContestModels>();
            Status = new Status();
            LastDataRFSpotContestModels = new RFSpotContestModels();
        }
    }
}
