using Practical_13.Models.Entities;
using Practical_13.Models.ViewModels;
using System.Collections.Generic;

namespace Practical_13.Models.Interfaces
{
    public interface ITask2EmployeeRepository
    {
        IEnumerable<Task2Employee> GetAllEmployees();
        Task2Employee GetEmployeeById(int id);
        void Insert(Task2Employee emp);
        void Update(Task2Employee emp);
        void Delete(int id);
        IEnumerable<EmployeeDetailsViewModel> GetEmployeeDetails();
        IEnumerable<DesignationEmployeeCountViewModel> GetEmployeeCount();
        void Save();
    }
}
