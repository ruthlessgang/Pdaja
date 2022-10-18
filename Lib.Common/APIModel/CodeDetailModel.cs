using System.Collections.Generic;

namespace Lib.Common.APIModel
{
    public class CodeDetailRequest
    {
        public string ID { get; set; }
        public long CodeTypeID { get; set; }
        public string Description { get; set; }
        public string DescriptionMore { get; set; }
    }

    public class CodeDetailResponse
    {
        public List<CodeDetailRequest> CodeDetails { get; set; }
        public Status Status { get; set; }

        public CodeDetailResponse()
        {
            CodeDetails = new List<CodeDetailRequest>();
            Status = new Status();
        }
    }
}