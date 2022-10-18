using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class Address
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<Address>();
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
                this.UpdateSave<Address>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<Address> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.Addresses
                .Where(x => x.IsDeleted == false);
        }

        public static Address GetAddressByString(string provinsi, string kabupaten, string kecamatan, string kelurahan)
        {
            IQueryable<Address> res = GetAll().Where(x => x.NAMA_PROVINSI.ToLower().Trim() == provinsi.ToLower().Trim() 
                                                    && x.NAMA_KABUPATEN_KODYA.ToLower().Trim() == kabupaten.ToLower().Trim()
                                                    && x.NAMA_KECAMATAN.ToLower().Trim() == kecamatan.ToLower().Trim()
                                                    && x.NAMA_KELURAHAN.ToLower().Trim() == kelurahan.ToLower().Trim());
            return res.FirstOrDefault();
        }

        public static Address GetAddressWithKodePos(string kodepos)
        {
            IQueryable<Address> res = GetAll().Where(x => x.KODE_POS.Trim() == kodepos.Trim());
            return res.FirstOrDefault();
        }

        public static Address GetAddressByID(long provinsiID, long kabupatenID, long kecamatanID, long kelurahanID)
        {
            IQueryable<Address> res = GetAll().Where(x => x.ID_RFPROVINSI == provinsiID
                                                    && x.ID_RFKABUPATEN_KODYA == kabupatenID
                                                    && x.ID_RFKECAMATAN == kecamatanID
                                                    && x.ID_RFKELURAHAN == kelurahanID);
            return res.FirstOrDefault();
        }

        public static Address GetKabupatenByName(string KabupatenName)
        {
            IQueryable<Address> res = GetAll().Where(x => x.NAMA_KABUPATEN_KODYA == KabupatenName);
            return res.FirstOrDefault();
        }

        public static List<Address> GetAddressListWithKodePos(string kodepos)
        {
            IQueryable<Address> res = GetAll().Where(x => x.KODE_POS.Trim() == kodepos.Trim());
            return res != null && res.Count() > 0 ? res.ToList() : new List<Address>();
        }
    }
}
