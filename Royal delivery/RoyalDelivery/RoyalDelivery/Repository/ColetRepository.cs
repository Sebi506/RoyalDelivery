using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;
using System.Drawing;

namespace RoyalDelivery.Repository
{
    public class ColetRepository
    {
        private ApplicationDbContext dbContext;

        public ColetRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ColetRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ColetModel> GetAllColets()
        {
            List<ColetModel> coletslist = new List<ColetModel>();

            foreach (Colet colet in dbContext.Colets)
            {
                coletslist.Add(MapDbObjectToModel(colet));
            }

            return coletslist;
        }

        public ColetModel GetColetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Colets.FirstOrDefault(x => x.IdColet == ID));
        }

        public List<ColetModel> GetColetsByLivrator(Guid id)
        {
            List<ColetModel> coletList = new List<ColetModel>();

            var foundColet = dbContext.Colets
                .Where(colet => colet.IdLivrator== id)
                .ToList();

            foreach (Colet colet in foundColet)
            {
                coletList.Add(MapDbObjectToModel(colet));
            }

            return coletList;
        }

        public List<ColetModel> GetColetByAwb(string searchTerm)
        {
            List<ColetModel> coletList = new List<ColetModel>();

            var foundColet = dbContext.Colets
                .Where(colet => colet.Awb.Contains(searchTerm))
                .ToList();

            foreach (Colet colet in foundColet)
            {
                coletList.Add(MapDbObjectToModel(colet));
            }

            return coletList;
        }

        public Guid GetDateLivrareIDbyID(Guid ID)
        {
            ColetModel colet = MapDbObjectToModel(dbContext.Colets.FirstOrDefault(x => x.IdColet == ID));

            return colet.IdDateLivrare;

        }

        public Guid GetInformatiiPlata(Guid ID)
        {
            ColetModel colet = MapDbObjectToModel(dbContext.Colets.FirstOrDefault(x => x.IdColet == ID));

            return colet.IdInformatiiPlata;

        }

        public void InsertColet(ColetModel coletModel)
        {
            coletModel.IdColet = Guid.NewGuid();

            dbContext.Colets.Add(MapModelToDbObject(coletModel));
            dbContext.SaveChanges();
        }

        public void UpdateColet(ColetModel coletModel)
        {
            Colet coletExistent = dbContext.Colets.FirstOrDefault(x => x.IdColet == coletModel.IdColet);

            if (coletExistent != null)
            {

                coletExistent.IdColet = coletModel.IdColet;
                coletExistent.IdDateLivrare = coletModel.IdDateLivrare;
                coletExistent.IdInformatiiPlata = coletModel.IdInformatiiPlata;
                coletExistent.IdLivrator = coletModel.IdLivrator;
                coletExistent.Awb = coletModel.Awb;
                coletExistent.StareColet = coletModel.StareColet;
                coletExistent.LocatieDepozit = coletModel.LocatieDepozit;
                dbContext.SaveChanges();
            }

        }

        public void DeteleColet(Guid id)
        {
            Colet coletExistent = dbContext.Colets.FirstOrDefault(x => x.IdColet == id);

            if (coletExistent != null)
            {

                dbContext.Colets.Remove(coletExistent);
                dbContext.SaveChanges();
            }

        }

        private ColetModel MapDbObjectToModel(Colet colet)
        {
            ColetModel coletModel = new ColetModel();

            if (colet != null)
            {
                coletModel.IdColet = colet.IdColet;
                coletModel.IdDateLivrare = colet.IdDateLivrare;
                coletModel.IdInformatiiPlata = colet.IdInformatiiPlata;
                coletModel.IdLivrator = colet.IdLivrator;
                coletModel.Awb = colet.Awb;
                coletModel.StareColet = colet.StareColet;
                coletModel.LocatieDepozit = colet.LocatieDepozit;
            }

            return coletModel;

        }

        private Colet MapModelToDbObject(ColetModel coletModel)
        {
            Colet colet = new Colet();

            if (coletModel != null)
            {
                colet.IdColet = coletModel.IdColet;
                colet.IdDateLivrare = coletModel.IdDateLivrare;
                colet.IdInformatiiPlata = coletModel.IdInformatiiPlata;
                colet.IdLivrator = coletModel.IdLivrator;
                colet.Awb = coletModel.Awb;
                colet.StareColet = coletModel.StareColet;
                colet.LocatieDepozit = coletModel.LocatieDepozit;
            }

            return colet;

        }

        public ColetDetailedModel MapColetToDetailedColet(ColetModel coletModel)
        {
            ColetDetailedModel colet = new ColetDetailedModel();

            if (coletModel != null)
            {
                colet.Awb = coletModel.Awb;
                colet.StareColet = coletModel.StareColet;
                colet.LocatieDepozit = coletModel.LocatieDepozit;

            }
            return colet;
        }
    }
}