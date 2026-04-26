using Practical_13.Models.Entities;
using Practical_13.Models.Interfaces;
using Practical_13.Models.Services;
using System.Net;
using System.Web.Mvc;

namespace Practical_13.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo = new EmployeeRepository();
        // GET: Employee
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = repo.GetById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {

            if(ModelState.IsValid)
            {
                repo.Insert(emp);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = repo.GetById(id);
            if(emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if(ModelState.IsValid && emp != null)
            {
                repo.Update(emp);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = repo.GetById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}
