using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class WordingPRK
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<WordingPRK>();
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
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<WordingPRK>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<WordingPRK> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.WordingPRKs
                .Where(x => !x.IsDeleted)
                .OrderByDescending(y => y.ID);
        }

        public static WordingPRK GetByID(long ID)
        {
            IQueryable<WordingPRK> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static WordingPRK GetWordingPRK()
        {
            IQueryable<WordingPRK> res = GetAll();
            return res.FirstOrDefault();
        }
    }
}
