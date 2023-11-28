using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Controllers
{
    public class DateLivrareController : Controller
    {
        private Repository.DateLivrareRepository _repository;
        private Repository.AdresaLivrareRepository _repositoryAdresaLivrare;
        private Repository.ContactClientRepository _repositoryContactClient;

        public DateLivrareController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.DateLivrareRepository(dbContext);
            _repositoryAdresaLivrare = new Repository.AdresaLivrareRepository(dbContext);
            _repositoryContactClient = new Repository.ContactClientRepository(dbContext);
        }

        // GET: DateLivrareController
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var deliveryData = _repository.GetAllDeliveryData();
            return View("Index", deliveryData);
        }

        // GET: DateLivrareController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetDeliveryDataByID(id);
            return View("DetailsDateLivrare", model);
        }

        // GET: DateLivrareController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateDateLivrare");
        }

        // POST: DateLivrareController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.DateLivrareModel model = new Models.DBObjects.DateLivrareModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.InsertDateLivrare(model);
                }

                return View("CreateDateLivrare");
            }
            catch
            {
                return View("CreateDateLivrare");
            }
        }

        // GET: DateLivrareController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetDeliveryDataByID(id);
            return View("EditDateLivrare", model);
        }

        // POST: DateLivrareController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DateLivrareModel();

                var task = TryUpdateModelAsync(model); task.Wait();
                if (task.Result)
                {
                    _repository.UpdateDateLivrare(model);
                    return RedirectToAction("Index", id);
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: DateLivrareController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetDeliveryDataByID(id);
            return View("DeleteDateLivrare", model);
        }

        // POST: DateLivrareController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                Guid idAdresa = _repository.GetAdresaIdByID(id);
                Guid idContactClient = _repository.GetContactCltientIdByID(id);
                _repository.DeleteDateLivrare(id);
                _repositoryAdresaLivrare.DeleteAdresa(idAdresa);
                _repositoryContactClient.DeleteClient(idContactClient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteDateLivrare", id);
            }
        }
    }
}
