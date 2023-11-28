using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Repository
{
    public class InformatiiPlataRepository
    {
        private ApplicationDbContext dbContext;

        public InformatiiPlataRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public InformatiiPlataRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<InformatiiPlataModel> GetAllInformatiiPlata()
        {
            List<InformatiiPlataModel> informatiiPlataList = new List<InformatiiPlataModel>();

            foreach (InformatiiPlata informatiiPlata in dbContext.InformatiiPlata)
            {
                informatiiPlataList.Add(MapDbObjectToModel(informatiiPlata));
            }

            return informatiiPlataList;
        }

        public InformatiiPlataModel GetInformatiiPlataById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.InformatiiPlata.FirstOrDefault(x => x.IdInformatiiPlata == ID));
        }

        public void InsertInformatiiPlata(InformatiiPlataModel informatiiPlataModel)
        {
            informatiiPlataModel.IdInformatiiPlata = Guid.NewGuid();

            dbContext.InformatiiPlata.Add(MapModelToDbObject(informatiiPlataModel));
            dbContext.SaveChanges();
        }

        public void UpdateInformatiiPlata(InformatiiPlataModel informatiiPlataModel)
        {
            InformatiiPlata informatiiPlataExistent = dbContext.InformatiiPlata.FirstOrDefault(x => x.IdInformatiiPlata == informatiiPlataModel.IdInformatiiPlata);

            if (informatiiPlataExistent != null)
            {
                informatiiPlataExistent.IdInformatiiPlata = informatiiPlataModel.IdInformatiiPlata;
                informatiiPlataExistent.TipPlata = informatiiPlataModel.TipPlata;
                informatiiPlataExistent.SumaDatorata = informatiiPlataModel.SumaDatorata;
                dbContext.SaveChanges();
            }

        }

        public void DeleteInformatiiPlata(Guid id)
        {
            InformatiiPlata informatiiPlataExistent = dbContext.InformatiiPlata.FirstOrDefault(x => x.IdInformatiiPlata == id);

            if (informatiiPlataExistent != null)
            {
                dbContext.InformatiiPlata.Remove(informatiiPlataExistent);
                dbContext.SaveChanges();
            }
        }

        private InformatiiPlataModel MapDbObjectToModel(InformatiiPlata informatiiPlata)
        {
            InformatiiPlataModel informatiiPlataModel = new InformatiiPlataModel();

            if (informatiiPlata != null)
            {
                informatiiPlataModel.IdInformatiiPlata = informatiiPlata.IdInformatiiPlata;
                informatiiPlataModel.TipPlata = informatiiPlata.TipPlata;
                informatiiPlataModel.SumaDatorata = informatiiPlata.SumaDatorata;
            }

            return informatiiPlataModel;
        }

        private InformatiiPlata MapModelToDbObject(InformatiiPlataModel informatiiPlataModel)
        {
            InformatiiPlata informatiiPlata = new InformatiiPlata();

            if (informatiiPlataModel != null)
            {
                informatiiPlata.IdInformatiiPlata = informatiiPlataModel.IdInformatiiPlata;
                informatiiPlata.TipPlata = informatiiPlataModel.TipPlata;
                informatiiPlata.SumaDatorata = informatiiPlataModel.SumaDatorata;
            }
            return informatiiPlata;
        }
        public ColetDetailedModel MapColetToDetailedColet(ColetDetailedModel colet, InformatiiPlataModel informatiiPlataModel)
        {
            if (informatiiPlataModel != null)
            {
                colet.TipPlata = informatiiPlataModel.TipPlata;
                colet.SumaDatorata = informatiiPlataModel.SumaDatorata;

            }
            return colet;
        }
    }

}