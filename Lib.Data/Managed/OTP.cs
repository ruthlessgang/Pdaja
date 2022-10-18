using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace Lib.Data
{
    public partial class OTP
    {
        public EFResponse Insert()
        {
            double expiredTIme = 2;
            double.TryParse(ConfigurationManager.AppSettings["ExpiredDBMinute"], out expiredTIme);
            EFResponse model = new EFResponse();
            try
            {
                this.CreateDate = DateTime.Now;
                this.ExpiredDate = DateTime.Now.AddMinutes(expiredTIme);
                this.Save<OTP>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<OTP> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.OTPs.Where(y => y.ExpiredDate.CompareTo(DateTime.Now) > 0);
        }

        public static IQueryable<OTP> GetAllWithoutExpired()
        {
            return DataRepositoryFactory.CurrentRepository.OTPs;
        }

        public static List<OTP> GetbyPhone(string phone)
        {
            IQueryable<OTP> res = GetAll().Where(x => x.Handphone.Trim() == phone.Trim());
            return res.ToList();
        }

        public static List<OTP> GetByPhonePerDay(string phone)
        {
            IQueryable<OTP> res = GetAllWithoutExpired().Where(x => x.Handphone == phone);
            return res.ToList();
        }

        public static OTP GetByPhoneCode(string Phone, string Code)
        {
            IQueryable<OTP> res = GetAll().Where(x => x.Handphone.Trim() == Phone.Trim() && x.Code.ToLower().Trim() == Code.ToLower().Trim());
            return res.FirstOrDefault();
        }
        
    }
}
