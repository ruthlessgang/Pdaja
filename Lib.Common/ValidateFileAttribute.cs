using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lib.Common
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent =  1024 *  1024 * 1024; //1000 MB
            string[] sAllowedExt = new string[] { ".jpg", ".gif", ".png", ".jpeg" };


            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.ToLower().Substring(file.FileName.ToLower().LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }   

    }

    public class ValidateFileAttributeEdit : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024 * 1024; //1000 MB
            string[] sAllowedExt = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            bool valid = true;

            var file = value as HttpPostedFileBase;

            if (file != null)
            {
                if (!sAllowedExt.Contains(file.FileName.ToLower().Substring(file.FileName.ToLower().LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", sAllowedExt);
                    valid =  false;
                }
                else if (file.ContentLength > maxContent)
                {
                    ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                    valid =  false;
                }
            }

            return valid;
        }

    }

    public class ValidatePDFAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024 * 1024; //1000 MB
            string[] sAllowedExt = new string[] { ".pdf" };


            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.ToLower().Substring(file.FileName.ToLower().LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload file of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }

    }

    public class ValidatePDFAttributeEdit : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024 * 1024; //1000 MB
            string[] sAllowedExt = new string[] { ".pdf" };
            bool valid = true;

            var file = value as HttpPostedFileBase;

            if (file != null)
            {
                if (!sAllowedExt.Contains(file.FileName.ToLower().Substring(file.FileName.ToLower().LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Your file of type: " + string.Join(", ", sAllowedExt);
                    valid = false;
                }
                else if (file.ContentLength > maxContent)
                {
                    ErrorMessage = "Your File is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                    valid = false;
                }
            }

            return valid;
        }

    }

   
}