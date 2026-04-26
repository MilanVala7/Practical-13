using System.Collections.Generic;
using Practical_13.Models.Entities;

namespace Practical_13.Models.Interfaces
{
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetAll();
        Designation GetById(int id);
        void Insert(Designation d);
        void Update(Designation d);
        void Delete(int id);
        void Save();
    }
}