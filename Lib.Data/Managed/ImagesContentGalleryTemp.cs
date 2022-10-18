using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ImagesContentGalleryTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ImagesContentGalleryTemp>();
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
                this.UpdateSave<ImagesContentGalleryTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ImagesContentGalleryTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ImagesContentGalleryTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static ImagesContentGalleryTemp GetByID(long ID)
        {
            IQueryable<ImagesContentGalleryTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ImagesContentGalleryTemp GetByImagesIDandTypeDocument(long ImagesContentGalleryID, int TypeDocument)
        {
            IQueryable<ImagesContentGalleryTemp> res = GetAll().Where(x => x.ImagesContentGalleryID == ImagesContentGalleryID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
