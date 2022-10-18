using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.Common.DataModel
{
    public class AdminModelAdd
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string KonfirmasiPassword { get; set; }        
        public string Name { get; set; }
        public string IsSuperUserString { get; set; }
    }

    public class AdminModelEdit
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string KonfirmasiPassword { get; set; }
        public string Name { get; set; }
        public string IsSuperUserString { get; set; }
    }

    public class MenuModel {
        public long ParentID { get; set; }
        public string ParentMenuString { get; set; }        
        public string Menu { get; set; }        
        public string LinkUrl { get; set; }       
        public int? Sort { get; set; }
        public string MenuTypeString { get; set; }
        public string IconClass { get; set; }
        public string IsShowCount { get; set; }
    }

    public class RoleModel {
        
        public string UserNameRole { get; set; }        
        public string Menu { get; set; }
        public string MenuTypeString { get; set; }
    }

    
}