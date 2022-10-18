using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ValidasiKabupaten
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ValidasiKabupaten>();
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
                this.UpdateSave<ValidasiKabupaten>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ValidasiKabupaten> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ValidasiKabupatens
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.NamaKabupaten);
        }

        public static ValidasiKabupaten GetByID(long ID)
        {
            IQueryable<ValidasiKabupaten> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ValidasiKabupaten GetByNamaKabupaten(string NamaKabupaten)
        {
            IQueryable<ValidasiKabupaten> res = GetAll().Where(x => x.NamaKabupaten.Trim().ToLower() == NamaKabupaten.Trim().ToLower());
            return res.FirstOrDefault();
        }

        public static ValidasiKabupaten GetByNamaKabupatenNotAccess(string namaKab)
        {
            IQueryable<ValidasiKabupaten> res = GetAll().Where(x => x.NamaKabupaten.ToLower().Replace("kab. ", "").Replace("kabupaten ", "").Replace("kab ", "").Trim() == namaKab.ToLower().Replace("kab. ", "").Replace("kabupaten ", "").Replace("kab ", "").Trim() && x.IsValid == false && x.IsApproved);
            return res.FirstOrDefault();
        }
    }
}
