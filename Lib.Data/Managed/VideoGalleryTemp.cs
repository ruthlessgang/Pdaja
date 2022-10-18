using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class VideoGalleryTemp
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<VideoGalleryTemp>();
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
                this.UpdateSave<VideoGalleryTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<VideoGalleryTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.VideoGalleryTemps
                .Where(x => !x.IsDeleted)
                .Where(x => !x.IsSuccess && x.TypeDocument != 1 && !x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }

        public static VideoGalleryTemp GetByID(long ID)
        {
            IQueryable<VideoGalleryTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static VideoGalleryTemp GetByVideoGalleryID(long VideoGalleryID)
        {
            IQueryable<VideoGalleryTemp> res = DataRepositoryFactory.CurrentRepository.VideoGalleryTemps.Where(x => x.VideoGalleryID == VideoGalleryID);
            return res.FirstOrDefault();
        }

        public static IQueryable<VideoGalleryTemp> GetVideoGalleryTemp()
        {
            IQueryable<VideoGalleryTemp> res = GetAll().Where(x => !x.IsDeleted);
            return res;
        }

        public static VideoGalleryTemp GetByVideoGalleryIDandTypeDocument(long videoGallery, int TypeDocument)
        {
            IQueryable<VideoGalleryTemp> res = GetAll().Where(x => x.VideoGalleryID == videoGallery && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<VideoGalleryTemp>();
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
