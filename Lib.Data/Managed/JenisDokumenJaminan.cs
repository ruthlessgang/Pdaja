using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class JenisDokumenJaminan
    {
        public static IQueryable<JenisDokumenJaminan> GetAllActive()
        {
            return DataRepositoryFactory.CurrentRepository.JenisDokumenJaminans
                .Where(x => x.ACTIVE && !x.IsDeleted)
                .OrderBy(x => x.DOC_CODE);
        }

        public static IQueryable<JenisDokumenJaminan> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.JenisDokumenJaminans
                .OrderBy(x => x.DOC_CODE);
        }

        public static JenisDokumenJaminan GetByCode(string code)
        {
            var allData = DataRepositoryFactory.CurrentRepository.JenisDokumenJaminans
                .Where(x => x.DOC_CODE == code);

            if (allData == null || allData.ToList().Count == 0)
                return null;

            return allData.First();
        }

        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<JenisDokumenJaminan>();
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
                this.UpdateSave<JenisDokumenJaminan>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }
    }
}
