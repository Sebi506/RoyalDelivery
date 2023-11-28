using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Repository
{
    public class AdresaLivrareRepository
    {
        private ApplicationDbContext dbContext;

        public AdresaLivrareRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AdresaLivrareRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AdresaLivrareModel> GetAllAdresses()
        {
            List<AdresaLivrareModel> adressesList = new List<AdresaLivrareModel>();

            foreach (AdresaLivrare dbAdresa in dbContext.AdresaLivrares)
            {
                adressesList.Add(MapDbObjectToModel(dbAdresa));
            }
            return adressesList;
        }

        public AdresaLivrareModel GetAdresaById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.AdresaLivrares.FirstOrDefault(x => x.IdAdresaLivrare == ID));
        }

        public void InsertAdresa(AdresaLivrareModel adresaModel)
        {
            adresaModel.IdAdresaLivrare = Guid.NewGuid();

            dbContext.AdresaLivrares.Add(MapModelToDbObject(adresaModel));
            dbContext.SaveChanges();
        }

        public void UpdateAdresa(AdresaLivrareModel adresaModel)
        {
            AdresaLivrare adresaExistenta = dbContext.AdresaLivrares.FirstOrDefault(x => x.IdAdresaLivrare == adresaModel.IdAdresaLivrare);

            if (adresaExistenta != null)
            {
                adresaExistenta.IdAdresaLivrare = adresaModel.IdAdresaLivrare;
                adresaExistenta.Judet = adresaModel.Judet;
                adresaExistenta.Oras = adresaModel.Oras;
                adresaExistenta.Strada = adresaModel.Strada;
                adresaExistenta.Numar = adresaModel.Numar;
                adresaExistenta.InformatiiAditionale = adresaModel.InformatiiAditionale;
                dbContext.SaveChanges();
            }

        }

        public void DeleteAdresa(Guid id)
        {
            AdresaLivrare adresaExistenta = dbContext.AdresaLivrares.FirstOrDefault(x => x.IdAdresaLivrare == id);

            if (adresaExistenta != null)
            {
                dbContext.AdresaLivrares.Remove(adresaExistenta);
                dbContext.SaveChanges();
            }
        }

        private AdresaLivrareModel MapDbObjectToModel(AdresaLivrare adresaLivrare)
        {
            AdresaLivrareModel adresaModel = new AdresaLivrareModel();

            if (adresaLivrare != null)
            {
                adresaModel.IdAdresaLivrare = adresaLivrare.IdAdresaLivrare;
                adresaModel.Judet = adresaLivrare.Judet;
                adresaModel.Oras = adresaLivrare.Oras;
                adresaModel.Strada = adresaLivrare.Strada;
                adresaModel.Numar = adresaLivrare.Numar;
                adresaModel.InformatiiAditionale = adresaLivrare.InformatiiAditionale;
            }

            return adresaModel;

        }

        private AdresaLivrare MapModelToDbObject(AdresaLivrareModel adresaModel)
        {
            AdresaLivrare adresaLivrare = new AdresaLivrare();

            if (adresaLivrare != null)
            {
                adresaLivrare.IdAdresaLivrare = adresaModel.IdAdresaLivrare;
                adresaLivrare.Judet = adresaModel.Judet;
                adresaLivrare.Oras = adresaModel.Oras;
                adresaLivrare.Strada = adresaModel.Strada;
                adresaLivrare.Numar = adresaModel.Numar;
                adresaLivrare.InformatiiAditionale = adresaModel.InformatiiAditionale;
            }

            return adresaLivrare;

        }
        public ColetDetailedModel MapColetToDetailedColet(ColetDetailedModel colet,AdresaLivrareModel adresaLivrare)
        {
            if (adresaLivrare != null)
            {
                colet.Judet = adresaLivrare.Judet;
                colet.Oras = adresaLivrare.Oras;
                colet.Strada = adresaLivrare.Strada;
                colet.Numar = adresaLivrare.Numar;
                colet.InformatiiAditionale = adresaLivrare.InformatiiAditionale;

            }
            return colet;
        }


    }
}