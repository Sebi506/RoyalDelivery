using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;
using RoyalDelivery.Repository;

namespace RoyalDelivery.Controllers
{
    public class AdresaLivrareController : Controller
    {
        private Repository.AdresaLivrareRepository _repository;

        public AdresaLivrareController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.AdresaLivrareRepository(dbContext);
        }
        // GET: AdresaLivrareController
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var adresaLivrare = _repository.GetAllAdresses();
            return View("Index", adresaLivrare);
        }

        // GET: AdresaLivrareController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetAdresaById(id);
            return View("DetailsAdresaLivrare", model);
        }

        // GET: AdresaLivrareController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateAdresaLivrare");
        }

        // POST: AdresaLivrareController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.AdresaLivrareModel model = new Models.DBObjects.AdresaLivrareModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.InsertAdresa(model);
                }

                return View("CreateAdresaLivrare");
            }
            catch
            {
                return View("CreateAdresaLivrare");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AdresaLivrareController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetAdresaById(id);
            return View("EditAdresaLivrare", model);
        }

        // POST: AdresaLivrareController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = new AdresaLivrareModel();

                var task = TryUpdateModelAsync(model); task.Wait();

                if (task.Result)
                {
                    _repository.UpdateAdresa(model);
                    return RedirectToAction("Index");
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

        // GET: AdresaLivrareController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetAdresaById(id);
            return View("DeleteAdresaLivrare", model);
        }

        // POST: AdresaLivrareController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteAdresa(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteAdresaLivrare", id);
            }
        }
    }
}
