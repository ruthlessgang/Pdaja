using System.Collections.Generic;

namespace Lib.Common.APIModel
{
    public class BungaPinjamanRequest
    {
        public string Id { get; set; }
        public decimal MinPlafond { get; set; }
        public decimal MaxPlafond { get; set; }
        public int Tenor { get; set; }
        public double Bunga { get; set; }
        public bool Active { get; set; }
        public int ID_RFKABUPATEN_KODYA { get; set; }
        public double PROVISI { get; set; }
    }

    public class BungaPinjamanResponse
    {
        public List<BungaPinjamanRequest> BungaPinjaman { get; set; }
        public Status Status { get; set; }

        public BungaPinjamanResponse()
        {
            BungaPinjaman = new List<BungaPinjamanRequest>();
            Status = new Status();
        }
    }

    public class GroupBungaPinjamanByTenorModel
    {
        public int Tenor { get; set; }
        public IEnumerable<BungaPinjamanRequest> ListBungaPinjaman { get; set; }
    }
}