using Practical_13.Models.Entities;
using System.Collections.Generic;

namespace Practical_13.Models.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int? id);
        void Insert(Employee emp);
        void Update(Employee emp);
        void Delete(int id);
        void Save();
    }
}
