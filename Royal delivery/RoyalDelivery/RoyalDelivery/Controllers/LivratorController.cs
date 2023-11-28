using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Controllers
{
    //[Authorize(Roles = "User,Admin")]
    public class LivratorController : Controller
    {
        private Repository.LivratorRepository _repository;

        public LivratorController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.LivratorRepository(dbContext);
        }

        // GET: LivratorController
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var livrators = _repository.GetAllLivrators();
            return View("Index", livrators);
        }

        // GET: LivratorController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetLivratorById(id);
            return View("DetailsLivrator", model);
        }

        // GET: LivratorController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateLivrator");
        }

        // POST: LivratorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.LivratorModel model = new Models.DBObjects.LivratorModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.InsertLivrator(model);
                }

                return View("CreateLivrator");
            }
            catch
            {
                return View("CreateLivrator");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LivratorController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetLivratorById(id);
            return View("EditLivrator", model);
        }

        // POST: LivratorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new LivratorModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.UpdateLivrator(model);

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

        // GET: LivratorController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetLivratorById(id);
            return View("DeleteLivrator", model);
        }

        // POST: LivratorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteLivrator(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteLivrator", id);
            }
        }
    }
}
