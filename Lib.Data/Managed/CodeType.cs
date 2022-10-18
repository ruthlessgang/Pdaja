using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class CodeType
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CodeType>();
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
                this.UpdateSave<CodeType>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<CodeType> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CodeTypes
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.CreatedDate);
        }

        public static CodeType GetByID(long ID)
        {
            IQueryable<CodeType> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }
    }
}
