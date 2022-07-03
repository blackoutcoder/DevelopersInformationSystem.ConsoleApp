using DevelopersInformationSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersInformationSystem.Infrastructure.Data
{
    public class DevInfoContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {

            Builder.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB; Database=DevInfoSystem; Trusted_Connection=True;");
        }
    }
}
