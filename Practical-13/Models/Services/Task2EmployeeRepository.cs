using Practical_13.Models.Data;
using Practical_13.Models.Entities;
using Practical_13.Models.Interfaces;
using Practical_13.Models.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Practical_13.Models.Services
{
    public class Task2EmployeeRepository : ITask2EmployeeRepository
    {
        private AppDbContext db = new AppDbContext();

        public IEnumerable<Task2Employee> GetAll()
        {
            return db.Task2Employees.Include(e => e.Designation).ToList();
        }

        public Task2Employee GetById(int id)
        {
            return db.Task2Employees.Find(id);
        }

        public void Insert(Task2Employee emp)
        {
            db.Task2Employees.Add(emp);
        }

        public void Update(Task2Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var emp = db.Task2Employees.Find(id);
            if (emp != null)
                db.Task2Employees.Remove(emp);
        }

        public IEnumerable<EmployeeDetailsViewModel> GetEmployeeDetails()
        {
            return db.Task2Employees.Include(e => e.Designation)
                .Select(e => new EmployeeDetailsViewModel
                {
                    EmployeeId = e.Id,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    DesignationName = e.Designation != null ? e.Designation.DesignationName : "No Designation",
                    DOB = e.DOB,
                    MobileNumber = e.MobileNumber,
                    Address = e.Address,
                    Salary = e.Salary
                }).ToList();
        }

        public IEnumerable<DesignationEmployeeCountViewModel> GetEmployeeCount()
        {
            return db.Designations
                .GroupJoin(db.Task2Employees,
                    d => d.Id,
                    e => e.DesignationId,
                    (d, employees) => new DesignationEmployeeCountViewModel
                    {
                        DesignationName = d.DesignationName,
                        EmployeeCount = employees.Count()
                    }).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}