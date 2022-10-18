using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.Common.DataModel
{
    public class CategoryModel
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string Type { get; set; }
    }
}