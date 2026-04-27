using Practical_13.Models.Entities;
using Practical_13.Models.Services;
using System.Net;
using System.Web.Mvc;

namespace Practical_13.Controllers
{
    public class Task2EmployeeController : Controller
    {
        private Task2EmployeeRepository repo = new Task2EmployeeRepository();
        private DesignationRepository dRepo = new DesignationRepository();

        public ActionResult Index()
        {
            return View(repo.GetAllEmployees());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = repo.GetEmployeeById(id.Value);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(dRepo.GetAllDesignations(), "Id", "DesignationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task2Employee emp)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(emp);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(dRepo.GetAllDesignations(), "Id", "DesignationName", emp.DesignationId);
            return View(emp);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = repo.GetEmployeeById(id.Value);

            if (emp == null)
                return HttpNotFound();

            ViewBag.DesignationId = new SelectList(dRepo.GetAllDesignations(), "Id", "DesignationName", emp.DesignationId);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task2Employee emp)
        {
            if (ModelState.IsValid)
            {
                repo.Update(emp);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(dRepo.GetAllDesignations(), "Id", "DesignationName", emp.DesignationId);
            return View(emp);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = repo.GetEmployeeById(id.Value);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeDetail()
        {
            return View(repo.GetEmployeeDetails());
        }

        public ActionResult EmployeeCountByDesignation()
        {
            return View(repo.GetEmployeeCount());
        }
    }
}