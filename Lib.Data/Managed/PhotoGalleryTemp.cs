using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class PhotoGalleryTemp
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<PhotoGalleryTemp>();
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
                this.UpdateSave<PhotoGalleryTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<PhotoGalleryTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.PhotoGalleryTemps
                .Where(x => !x.IsDeleted)
                .Where(x => !x.IsSuccess && x.TypeDocument != 1 && !x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }

        public static PhotoGalleryTemp GetByID(long ID)
        {
            IQueryable<PhotoGalleryTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<PhotoGalleryTemp> GetPhotoGalleryTemp()
        {
            IQueryable<PhotoGalleryTemp> res = GetAll().Where(x => !x.IsDeleted);
            return res;
        }

        public static PhotoGalleryTemp GetByPhotoGalleryIDandTypeDocument(long photoGalleryID, int TypeDocument)
        {
            IQueryable<PhotoGalleryTemp> res = GetAll().Where(x => x.PhotoGalleryID == photoGalleryID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<PhotoGalleryTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }
        
        public static PhotoGalleryTemp GetByPhotoGalleryID(long PhotoGalleryID)
        {
            IQueryable<PhotoGalleryTemp> res = DataRepositoryFactory.CurrentRepository.PhotoGalleryTemps.Where(x => x.PhotoGalleryID == PhotoGalleryID);
            return res.FirstOrDefault();
        }
    }
}
