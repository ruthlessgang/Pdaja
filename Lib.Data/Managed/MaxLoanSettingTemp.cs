using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class MaxLoanSettingTemp
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<MaxLoanSettingTemp>();
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
                this.UpdateSave<MaxLoanSettingTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<MaxLoanSettingTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.MaxLoanSettingTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static MaxLoanSettingTemp GetByID(long ID)
        {
            IQueryable<MaxLoanSettingTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static MaxLoanSettingTemp GetByMaxLoanSettingIDandTypeDocument(long MaxLoanSettingID, int TypeDocument)
        {
            IQueryable<MaxLoanSettingTemp> res = GetAll().Where(x => x.MaxLoanSettingID == MaxLoanSettingID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public static MaxLoanSettingTemp GetByArticleID(long MaxLoanSettingID)
        {
            IQueryable<MaxLoanSettingTemp> res = DataRepositoryFactory.CurrentRepository.MaxLoanSettingTemps
                .Where(x => x.MaxLoanSettingID == MaxLoanSettingID);
            return res.FirstOrDefault();
        }
    }
}
