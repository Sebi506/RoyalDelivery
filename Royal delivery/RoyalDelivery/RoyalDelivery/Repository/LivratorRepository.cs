using Microsoft.EntityFrameworkCore.Migrations.Internal;
using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Repository
{
    public class LivratorRepository
    {
        private ApplicationDbContext dbContext;

        public LivratorRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public LivratorRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<LivratorModel> GetAllLivrators()
        {
            List<LivratorModel> livratorList = new List<LivratorModel>();

            foreach (Livrator livrator in dbContext.Livrators)
            {
                livratorList.Add(MapDbObjectToModel(livrator));
            }

            return livratorList;
        }

        public LivratorModel GetLivratorById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Livrators.FirstOrDefault(x => x.IdLivrator == ID));
        }

        public void InsertLivrator(LivratorModel livratorModel)
        {
            livratorModel.IdLivrator = Guid.NewGuid();

            dbContext.Livrators.Add(MapModelToDbObject(livratorModel));
            dbContext.SaveChanges();
        }

        public void UpdateLivrator(LivratorModel livratorModel)
        {
            Livrator livratorExistent = dbContext.Livrators.FirstOrDefault(x => x.IdLivrator == livratorModel.IdLivrator);

            if (livratorExistent != null)
            {
                livratorExistent.IdLivrator = livratorModel.IdLivrator;
                livratorExistent.Nume = livratorModel.Nume;
                livratorExistent.Prenume = livratorModel.Prenume;
                livratorExistent.JudetActivitate = livratorModel.JudetActivitate;
                dbContext.SaveChanges();
            }

        }

        public void DeleteLivrator(Guid ID)
        {
            Livrator livratorExistent = dbContext.Livrators.FirstOrDefault(x => x.IdLivrator == ID);

            if (livratorExistent != null)
            {
                dbContext.Livrators.Remove(livratorExistent);
                dbContext.SaveChanges();
            }
        }

        private LivratorModel MapDbObjectToModel(Livrator livrator)
        {
            LivratorModel livratorModel = new LivratorModel();

            if (livrator != null)
            {
                livratorModel.IdLivrator = livrator.IdLivrator;
                livratorModel.Nume = livrator.Nume;
                livratorModel.Prenume = livrator.Prenume;
                livratorModel.JudetActivitate = livrator.JudetActivitate;
            }

            return livratorModel;
        }

        private Livrator MapModelToDbObject(LivratorModel livratorModel)
        {
            Livrator livrator = new Livrator();

            if (livratorModel != null)
            {
                livrator.IdLivrator = livratorModel.IdLivrator;
                livrator.Nume = livratorModel.Nume;
                livrator.Prenume = livratorModel.Prenume;
                livrator.JudetActivitate = livratorModel.JudetActivitate;
            }
            return livrator;
        }
    }

}