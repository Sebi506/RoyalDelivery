using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalDelivery.Data;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Controllers
{
    public class ContactClientController : Controller
    {
        private Repository.ContactClientRepository _repository;

        public ContactClientController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ContactClientRepository(dbContext);
        }
        // GET: ContactClientController
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var contactClienti = _repository.GetAllClients();
            return View("Index", contactClienti);
        }

        // GET: ContactClientController/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetContactClientById(id);
            return View("DetailsContactClient", model);
        }

        // GET: ContactClientController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateContactClient");
        }

        // POST: ContactClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.ContactClientModel model = new Models.DBObjects.ContactClientModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.InsertClient(model);
                }
                return View("CreateContactClient");
            }
            catch
            {
                return View("CreateContactClient");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactClientController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetContactClientById(id);
            return View("EditContactClient", model);
        }

        // POST: ContactClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = new ContactClientModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _repository.UpdateClient(model);
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

        // GET: ContactClientController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetContactClientById(id);
            return View("DeleteContactClient", model);
        }

        // POST: ContactClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteClient(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteContactClient", id);
            }
        }
    }
}
