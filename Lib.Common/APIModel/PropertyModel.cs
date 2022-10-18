using System.Collections.Generic;

namespace Lib.Common.APIModel
{
    public class PropertyRequest
    {
        public long ID_DATA_ASSET { get; set; }
        public string NAMA_PERUMAHAN { get; set; }
        public string STATUS_POST { get; set; }
        public bool IS_DELETED { get; set; }
        public string KABUPATEN_KODYA { get; set; }
        public string JENIS_ASSET { get; set; }
    }

    public class PropertyResponse
    {
        public List<PropertyRequest> Property { get; set; }
        public Status Status { get; set; }

        public PropertyResponse()
        {
            Property = new List<PropertyRequest>();
            Status = new Status();
        }
    }

    public class PropertyRequestAsync
    {
        public long ID_DATA_ASET { get; set; }
        public string NAMA_PERUMAHAN { get; set; }
        public string STATUS_POST { get; set; }
        public bool IS_DELETED { get; set; }
        public string KABUPATEN_KODYA { get; set; }
        public string JENIS_ASSET { get; set; }
    }

    public class PropertyResponseSync
    {
        public List<PropertyRequestAsync> Property { get; set; }
        public Status Status { get; set; }

        public PropertyResponseSync()
        {
            Property = new List<PropertyRequestAsync>();
            Status = new Status();
        }
    }
}