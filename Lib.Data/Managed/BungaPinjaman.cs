using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class BungaPinjaman
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<BungaPinjaman>();
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
                this.UpdateSave<BungaPinjaman>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<BungaPinjaman> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.BungaPinjamen
                .Where(x => x.Active)
                .OrderBy(x => x.Bunga);
        }

        public static BungaPinjaman GetMaxTenor()
        {
            IQueryable<BungaPinjaman> res = GetAll()
                .Where(x => x.Active)
                .OrderByDescending(x => x.Tenor);

            return res.FirstOrDefault();
        }

        public static IQueryable<BungaPinjaman> GetByTenor(int Tenor)
        {
            IQueryable<BungaPinjaman> res = GetAll().Where(x => x.Tenor == Tenor);
            return res;
        }

        public static BungaPinjaman GetByIDMinPlafondBunga(string ID, decimal MinPlafond, double Bunga)
        {
            IQueryable<BungaPinjaman> res = GetAll().Where(x => x.ID.Trim() == ID.Trim() && x.MinPlafond == MinPlafond && x. Bunga == Bunga);
            return res.FirstOrDefault();
        }

    }
}
