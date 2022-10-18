namespace Lib.Common.DataModel
{
    public class MenuWebModel
    {
        public long ID { get; set; }
        public long ParentID { get; set; }
        public string ParentIDString { get; set; }
        public string MenuName { get; set; }
        public string LinkUrl { get; set; }
        public string Slug { get; set; }
        public bool IsContent { get; set; }
        public string IsContentString { get; set; }
        public int Sort { get; set; }
    }
}