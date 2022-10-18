using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class PhotoGalleryListTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<PhotoGalleryListTemp>();
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
                this.UpdateSave<PhotoGalleryListTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<PhotoGalleryListTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.PhotoGalleryListTemps
                .OrderBy(x => x.ID);
        }

        public static PhotoGalleryListTemp GetByID(long ID)
        {
            IQueryable<PhotoGalleryListTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<PhotoGalleryListTemp> GetPhotoGalleryListTemp(long PhotoGalleryTempID)
        {
            IQueryable<PhotoGalleryListTemp> res = GetAll().Where(x => x.PhotoGalleryTempID == PhotoGalleryTempID);
            return res;
        }

        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<PhotoGalleryListTemp>();
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
