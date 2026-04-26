using Practical_13.Models.Entities;
using System.Data.Entity;

namespace Practical_13.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=connString") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task2Employee> Task2Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}