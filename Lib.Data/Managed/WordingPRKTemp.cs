using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class WordingPRKTemp
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<WordingPRKTemp>();
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
                this.UpdateSave<WordingPRKTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<WordingPRKTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.WordingPRKTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static WordingPRKTemp GetByID(long ID)
        {
            IQueryable<WordingPRKTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static WordingPRKTemp GetByMaxLoanSettingIDandTypeDocument(long WordingPRKID, int TypeDocument)
        {
            IQueryable<WordingPRKTemp> res = GetAll().Where(x => x.WordingPRKID == WordingPRKID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public static WordingPRKTemp GetByMaxLoanSettingID(long WordingPRKID)
        {
            IQueryable<WordingPRKTemp> res = DataRepositoryFactory.CurrentRepository.WordingPRKTemps
                .Where(x => x.WordingPRKID == WordingPRKID);
            return res.FirstOrDefault();
        }
    }
}
