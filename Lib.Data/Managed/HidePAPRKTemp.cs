using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class HidePAPRKTemp
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<HidePAPRKTemp>();
                model.ID = this.ID;
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
            EFResponse model = new EFResponse();
            try
            {
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<HidePAPRKTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<HidePAPRKTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.HidePAPRKTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static HidePAPRKTemp GetByID(long ID)
        {
            IQueryable<HidePAPRKTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static HidePAPRKTemp GetByMaxLoanSettingIDandTypeDocument(long HidePAPRKID, int TypeDocument)
        {
            IQueryable<HidePAPRKTemp> res = GetAll().Where(x => x.HidePAPRKID == HidePAPRKID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public static HidePAPRKTemp GetByMaxLoanSettingID(long HidePAPRKID)
        {
            IQueryable<HidePAPRKTemp> res = DataRepositoryFactory.CurrentRepository.HidePAPRKTemps
                .Where(x => x.HidePAPRKID == HidePAPRKID);
            return res.FirstOrDefault();
        }
    }
}
