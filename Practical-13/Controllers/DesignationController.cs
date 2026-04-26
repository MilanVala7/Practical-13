using Practical_13.Models.Entities;
using Practical_13.Models.Services;
using System.Net;
using System.Web.Mvc;

namespace Practical_13.Controllers
{
    public class DesignationController : Controller
    {
        private DesignationRepository repo = new DesignationRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var d = repo.GetById(id.Value);

            if (d == null)
                return HttpNotFound();

            return View(d);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Designation d)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(d);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(d);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var d = repo.GetById(id.Value);

            if (d == null)
                return HttpNotFound();

            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Designation d)
        {
            if (ModelState.IsValid)
            {
                repo.Update(d);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(d);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var d = repo.GetById(id.Value);

            if (d == null)
                return HttpNotFound();

            return View(d);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}