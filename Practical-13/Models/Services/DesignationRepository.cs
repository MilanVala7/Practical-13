using Practical_13.Models.Data;
using Practical_13.Models.Entities;
using Practical_13.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Practical_13.Models.Services
{
    public class DesignationRepository : IDesignationRepository
    {
        private AppDbContext db = new AppDbContext();

        public IEnumerable<Designation> GetAll()
        {
            return db.Designations.ToList();
        }

        public Designation GetById(int id)
        {
            return db.Designations.Find(id);
        }

        public void Insert(Designation d)
        {
            db.Designations.Add(d);
        }

        public void Update(Designation d)
        {
            db.Entry(d).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var d = db.Designations.Find(id);
            if (d != null)
                db.Designations.Remove(d);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}