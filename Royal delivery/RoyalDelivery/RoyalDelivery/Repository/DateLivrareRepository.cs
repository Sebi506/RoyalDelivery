using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Repository
{
    public class DateLivrareRepository
    {
        private ApplicationDbContext dbContext;

        public DateLivrareRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public DateLivrareRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<DateLivrareModel> GetAllDeliveryData()
        {
            List<DateLivrareModel> dateLivrareList = new List<DateLivrareModel>();

            foreach (DateLivrare dateLivrare in dbContext.DateLivrares)
            {
                dateLivrareList.Add(MapDbObjectToModel(dateLivrare));
            }

            return dateLivrareList;
        }

        public List<DateLivrareModel> GetDeliveryDataByDate(DateTime date)
        {
            List<DateLivrareModel> dateLivrareList = new List<DateLivrareModel>();

            foreach (DateLivrare dateLivrare in dbContext.DateLivrares)
            {
                if (dateLivrare.DataLivrare == date)
                {
                    dateLivrareList.Add(MapDbObjectToModel(dateLivrare));
                }
            }

            return dateLivrareList;
        }

        public DateLivrareModel GetDeliveryDataByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.DateLivrares.FirstOrDefault(x => x.IdDateLivrare == ID));
        }

        public Guid GetAdresaIdByID(Guid ID)
        {
            DateLivrareModel dateLivrare = MapDbObjectToModel(dbContext.DateLivrares.FirstOrDefault(x => x.IdDateLivrare == ID));
         
                return dateLivrare.IdAdresaLivrare;
            
        }

        public Guid GetContactCltientIdByID(Guid ID)
        {
            DateLivrareModel dateLivrare = MapDbObjectToModel(dbContext.DateLivrares.FirstOrDefault(x => x.IdDateLivrare == ID));
            return dateLivrare.IdContactClient;
        }

        public void InsertDateLivrare(DateLivrareModel datelivrareModel)
        {
            datelivrareModel.IdDateLivrare = Guid.NewGuid();
            dbContext.DateLivrares.Add(MapModelToDbObject(datelivrareModel));
            dbContext.SaveChanges();
        }

        public void UpdateDateLivrare(DateLivrareModel dateLivrareModel)
        {
            DateLivrare dateLivrareExistent = dbContext.DateLivrares.FirstOrDefault(x => x.IdDateLivrare == dateLivrareModel.IdDateLivrare);
            if (dateLivrareExistent != null)
            {
                dateLivrareExistent.IdDateLivrare = dateLivrareModel.IdDateLivrare;
                dateLivrareExistent.IdAdresaLivrare = dateLivrareModel.IdAdresaLivrare;
                dateLivrareExistent.IdContactClient = dateLivrareModel.IdContactClient;
                dateLivrareExistent.DataLivrare = dateLivrareModel.DataLivrare;
                dbContext.SaveChanges();
            }

        }

        public void DeleteDateLivrare(Guid id)
        {
            DateLivrare dateLivrareExistent = dbContext.DateLivrares.FirstOrDefault(x => x.IdDateLivrare == id);

            if (dateLivrareExistent != null)
            {
                dbContext.DateLivrares.Remove(dateLivrareExistent);
                dbContext.SaveChanges();
            }
        }
        

    private DateLivrareModel MapDbObjectToModel(DateLivrare dateLivrare)
        {
            DateLivrareModel dateLivrareModel = new DateLivrareModel();

            if (dateLivrare != null)
            {
                dateLivrareModel.IdDateLivrare = dateLivrare.IdDateLivrare;
                dateLivrareModel.IdAdresaLivrare = dateLivrare.IdAdresaLivrare;
                dateLivrareModel.IdContactClient = dateLivrare.IdContactClient;
                dateLivrareModel.DataLivrare = dateLivrare.DataLivrare;

            }

            return dateLivrareModel;
        }

        private DateLivrare MapModelToDbObject(DateLivrareModel dateLivrareModel)
        {
            DateLivrare dateLivrare = new DateLivrare();

            if (dateLivrareModel != null)
            {
                dateLivrare.IdDateLivrare = dateLivrareModel.IdDateLivrare;
                dateLivrare.IdAdresaLivrare = dateLivrareModel.IdAdresaLivrare;
                dateLivrare.IdContactClient = dateLivrareModel.IdContactClient;
                dateLivrare.DataLivrare = dateLivrareModel.DataLivrare;
            }
            return dateLivrare;
        }

        public ColetDetailedModel MapColetToDetailedColet(ColetDetailedModel colet, DateLivrareModel dateLivrareModel)
        {
            if (dateLivrareModel != null)
            {
                colet.DataLivrare = dateLivrareModel.DataLivrare;

            }
            return colet;
        }
    }

}