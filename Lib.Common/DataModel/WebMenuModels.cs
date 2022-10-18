using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace PDaja.Com.CMS.Models
{
    public class WebMenuModels
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameEng { get; set; }

        [Required]
        public string NameMobile { get; set; }
        [Required]
        public string NameMobileEng { get; set; }

        [Required]
        public string ParentIDString { get; set; }

        [Required]
        public string Url { get; set; }

        public string InMobileString { get; set; }

        public string StatusString { get; set; }

        public long? ParentId { get; set; }

        public long? Status { get; set; }

        public long? InMobile { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int HideInNavigation { get; set; }
        public string HideInNavigationString { get; set; }
        public string Target { get; set; }
    }

    public class WebMenuRoleModel {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameEng { get; set; }
    }

    public class WebMenuRoleListModel {
        [Required]
        public string MenuIDString { get; set; }

        [Required]
        public string RoleIDString { get; set; }

        public long MenuId { get; set; }

        public long RoleId { get; set; }
    }
}