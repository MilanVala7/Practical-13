using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Practical_13.Models.Data;
using Practical_13.Models.Entities;
using Practical_13.Models.Interfaces;

namespace Practical_13.Models.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext db = new AppDbContext();

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int? id)
        {
            return db.Employees.Find(id);
        }

        public void Insert(Employee emp)
        {
            db.Employees.Add(emp);
        }

        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp != null)
                db.Employees.Remove(emp);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}