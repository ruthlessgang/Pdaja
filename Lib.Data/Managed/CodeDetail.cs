using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class CodeDetail
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CodeDetail>();
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
                this.UpdateSave<CodeDetail>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<CodeDetail> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CodeDetails
                .Where(x => !x.IsDeleted && x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }

        public static IQueryable<CodeDetail> GetAllByCodeTypeID(long codeTypeID)
        {
            return DataRepositoryFactory.CurrentRepository.CodeDetails
                .Where(x => !x.IsDeleted && x.IsApproved && x.CodeTypeID == codeTypeID)
                .OrderBy(x => x.ID);
        }

        public static CodeDetail GetByID(string ID)
        {
            IQueryable<CodeDetail> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }
    }
}
