using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFWHATSAPP
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFWHATSAPP>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public EFResponse Update()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                //this.UpdatedDate = DateTime.Now;
                this.UpdateSave<RFWHATSAPP>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFWHATSAPP> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFWHATSAPPs;
        }

        public static IQueryable<RFWHATSAPP> GetAllWithIsActive()
        {
            return GetAll().Where(x => x.IsActive == true);
        }

        public static RFWHATSAPP GetByPhoneNumber(string PhoneNumber)
        {
            IQueryable<RFWHATSAPP> res = GetAll().Where(x => x.PhoneNumber.Trim() == PhoneNumber.Trim());
            return res.FirstOrDefault();
        }
    }
}
