using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Controllers
{
    public class ColetController : Controller
    {

        private Repository.ColetRepository _repository;
        private Repository.DateLivrareRepository _repositoryDateLivrare;
        private Repository.InformatiiPlataRepository _repositoryInformatiiPlata;
        private Repository.AdresaLivrareRepository _repositoryAdresaLivrare;
        private Repository.ContactClientRepository _repositoryContactClient;

        public ColetController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ColetRepository(dbContext);
            _repositoryDateLivrare = new Repository.DateLivrareRepository(dbContext);
            _repositoryInformatiiPlata = new Repository.InformatiiPlataRepository(dbContext);
            _repositoryAdresaLivrare = new Repository.AdresaLivrareRepository(dbContext);
            _repositoryContactClient = new Repository.ContactClientRepository(dbContext);
        }
        // GET: ColetController
        public ActionResult Index()
        {
            var colets = _repository.GetAllColets();
            return View("Index", colets);
        }

        // GET: ColetController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            ColetModel modelColet = _repository.GetColetById(id);
            ColetDetailedModel modelDetaliat = _repository.MapColetToDetailedColet(modelColet);

            Guid idDateLivrare = _repository.GetDateLivrareIDbyID(id);
            Guid idAdresa = _repositoryDateLivrare.GetAdresaIdByID(idDateLivrare);
            Guid idContactClient = _repositoryDateLivrare.GetContactCltientIdByID(idDateLivrare);
            Guid idInformatiiPlata = _repository.GetInformatiiPlata(id);

            DateLivrareModel modelDateLivrare= _repositoryDateLivrare.GetDeliveryDataByID(idDateLivrare);
            modelDetaliat = _repositoryDateLivrare.MapColetToDetailedColet(modelDetaliat, modelDateLivrare);

            InformatiiPlataModel informatiiPlataModel = _repositoryInformatiiPlata.GetInformatiiPlataById(idInformatiiPlata);
             modelDetaliat = _repositoryInformatiiPlata.MapColetToDetailedColet(modelDetaliat, informatiiPlataModel);

            AdresaLivrareModel adresaLivrareModel = _repositoryAdresaLivrare.GetAdresaById(idAdresa);
             modelDetaliat = _repositoryAdresaLivrare.MapColetToDetailedColet(modelDetaliat, adresaLivrareModel);

            ContactClientModel contactClientModel = _repositoryContactClient.GetContactClientById(idContactClient);
             modelDetaliat = _repositoryContactClient.MapColetToDetailedColet(modelDetaliat, contactClientModel);

            return View("DetailsColet", modelDetaliat);
        }

        // GET: ColetController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateColet");
        }

        // POST: ColetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.ColetModel model = new Models.DBObjects.ColetModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                _repository.InsertColet(model);

                return View("CreateColet");
            }
            catch
            {
                return View("CreateColet");
            }
        }

        // GET: ColetController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetColetById(id);
            return View("EditColet", model);
        }

        // POST: ColetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ColetModel();
                var task = TryUpdateModelAsync(model); task.Wait();
                
                    _repository.UpdateColet(model);
                    return RedirectToAction("Index");
                

            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: ColetController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {

            var model = _repository.GetColetById(id);
            return View("DeleteColet", model);
        }

        // POST: ColetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                
                Guid idDateLivrare = _repository.GetDateLivrareIDbyID(id);
                Guid idAdresa = _repositoryDateLivrare.GetAdresaIdByID(idDateLivrare);
                Guid idContactClient = _repositoryDateLivrare.GetContactCltientIdByID(idDateLivrare);
                Guid idInformatiiPlata = _repository.GetInformatiiPlata(id);

                _repository.DeteleColet(id);

                _repositoryDateLivrare.DeleteDateLivrare(idDateLivrare);
                _repositoryInformatiiPlata.DeleteInformatiiPlata(idInformatiiPlata);
                _repositoryAdresaLivrare.DeleteAdresa(idAdresa);
                _repositoryContactClient.DeleteClient(idContactClient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteColet", id);
            }
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            if (searchTerm == null)
            {
                var colets = _repository.GetAllColets();
                return View("Index", colets);
            }
            else
            {
                var colets = _repository.GetColetByAwb(searchTerm);
                return View("Index", colets);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult Filter(string id)
        {
            Guid idLivrator = Guid.Parse(id);
            var colets = _repository.GetColetsByLivrator(idLivrator);
            return View("Index", colets);
        }
    }
}
