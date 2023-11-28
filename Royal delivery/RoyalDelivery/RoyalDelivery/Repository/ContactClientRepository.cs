using RoyalDelivery.Data;
using RoyalDelivery.Models;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Repository
{
    public class ContactClientRepository
    {
        private ApplicationDbContext dbContext;

        public ContactClientRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ContactClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ContactClientModel> GetAllClients()
        {

            List<ContactClientModel> contactClientList = new List<ContactClientModel>();

            foreach (ContactClient contactClient in dbContext.ContactClients)
            {
                contactClientList.Add(MapDbObjectToModel(contactClient));
            }

            return contactClientList;
        }

        public ContactClientModel GetContactClientById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.ContactClients.FirstOrDefault(x => x.IdContactClient == ID));
        }

        public void InsertClient(ContactClientModel contactClientModel)
        {
            contactClientModel.IdContactClient = Guid.NewGuid();

            dbContext.ContactClients.Add(MapModelToDbObject(contactClientModel));
            dbContext.SaveChanges();
        }

        public void UpdateClient(ContactClientModel contactClientModel)
        {
            ContactClient clientExistent = dbContext.ContactClients.FirstOrDefault(x => x.IdContactClient == contactClientModel.IdContactClient);

            if (clientExistent != null)
            {
                clientExistent.IdContactClient = contactClientModel.IdContactClient;
                clientExistent.Nume = contactClientModel.Nume;
                clientExistent.Prenume = contactClientModel.Prenume;
                clientExistent.Email = contactClientModel.Email;
                clientExistent.NumarTelefon = contactClientModel.NumarTelefon;
                dbContext.SaveChanges();
            }
        }

        public void DeleteClient(Guid id)
        {
            ContactClient clientExistent = dbContext.ContactClients.FirstOrDefault(x => x.IdContactClient == id);

            if (clientExistent != null)
            {
                dbContext.ContactClients.Remove(clientExistent);
                dbContext.SaveChanges();
            }

        }

        private ContactClientModel MapDbObjectToModel(ContactClient contactClient)
        {
            ContactClientModel contactClientModel = new ContactClientModel();

            if (contactClient != null)
            {
                contactClientModel.IdContactClient = contactClient.IdContactClient;
                contactClientModel.Nume = contactClient.Nume;
                contactClientModel.Prenume = contactClient.Prenume;
                contactClientModel.Email = contactClient.Email;
                contactClientModel.NumarTelefon = contactClient.NumarTelefon;

            }

            return contactClientModel;
        }

        private ContactClient MapModelToDbObject(ContactClientModel contactClientModel)
        {
            ContactClient contactClient = new ContactClient();

            if (contactClientModel != null)
            {
                contactClient.IdContactClient = contactClientModel.IdContactClient;
                contactClient.Nume = contactClientModel.Nume;
                contactClient.Prenume = contactClientModel.Prenume;
                contactClient.Email = contactClientModel.Email;
                contactClient.NumarTelefon = contactClientModel.NumarTelefon;
            }
            return contactClient;
        }
        public ColetDetailedModel MapColetToDetailedColet(ColetDetailedModel colet, ContactClientModel contactClientModel)
        {
            if (contactClientModel != null)
            {
                colet.Nume = contactClientModel.Nume;
                colet.Prenume = contactClientModel.Prenume;
                colet.Email = contactClientModel.Email;
                colet.NumarTelefon = contactClientModel.NumarTelefon;

            }
            return colet;
        }
    }
}