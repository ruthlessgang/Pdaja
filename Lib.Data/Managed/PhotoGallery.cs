using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class PhotoGallery
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<PhotoGallery>();
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
                this.UpdateSave<PhotoGallery>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<PhotoGallery> GetAllActive()
        {
            return DataRepositoryFactory.CurrentRepository.PhotoGalleries
                .Where(x => !x.IsDeleted && x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }

        public static IQueryable<PhotoGallery> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.PhotoGalleries
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedDate);
        }

        public static PhotoGallery GetByID(long ID)
        {
            IQueryable<PhotoGallery> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }        
    }
}
