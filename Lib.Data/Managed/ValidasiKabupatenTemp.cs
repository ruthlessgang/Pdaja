using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ValidasiKabupatenTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ValidasiKabupatenTemp>();
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
                this.UpdateSave<ValidasiKabupatenTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ValidasiKabupatenTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ValidasiKabupatenTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static ValidasiKabupatenTemp GetByID(long ID)
        {
            IQueryable<ValidasiKabupatenTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ValidasiKabupatenTemp GetByValidasiKabupatenIDandTypeDocument(long ValidasiKabupatenID, int TypeDocument)
        {
            IQueryable<ValidasiKabupatenTemp> res = GetAll().Where(x => x.ValidasiKabupatenID == ValidasiKabupatenID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
