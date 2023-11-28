using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Controllers
{
    public class InformatiiPlataController : Controller
    {

        private Repository.InformatiiPlataRepository _repository;

        public InformatiiPlataController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.InformatiiPlataRepository(dbContext);
        }
        // GET: InformatiiPlataController
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var informatiiPlata = _repository.GetAllInformatiiPlata();
            return View("Index", informatiiPlata);
        }

        // GET: InformatiiPlataController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetInformatiiPlataById(id);
            return View("DetailsInformatiiPlata", model);
        }

        // GET: InformatiiPlataController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateInformatiiPlata");
        }

        // POST: InformatiiPlataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.InformatiiPlataModel model = new Models.DBObjects.InformatiiPlataModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (model.TipPlata == "Card" && model.SumaDatorata == null)
                    model.SumaDatorata = 0;
                if (task.Result)
                {
                    _repository.InsertInformatiiPlata(model);
                }

                return View("CreateInformatiiPlata");
            }
            catch
            {
                return View("CreateInformatiiPlata");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: InformatiiPlataController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetInformatiiPlataById(id);
            return View("EditInformatiiPlata", model);
        }

        // POST: InformatiiPlataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new InformatiiPlataModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.UpdateInformatiiPlata(model);
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

        // GET: InformatiiPlataController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetInformatiiPlataById(id);
            return View("DeleteInformatiiPlata", model);
        }

        // POST: InformatiiPlataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteInformatiiPlata(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteAnnouncement", id);
            }
        }
    }
}
