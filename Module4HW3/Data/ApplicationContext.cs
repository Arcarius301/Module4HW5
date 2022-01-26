using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Data.Entities;
using Module4HW3.Data.EntityConfigurations;

namespace Module4HW3.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EemployeeProjects { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            builder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            builder.ApplyConfiguration(new EmployeeProjectEntityTypeConfiguration());
            builder.ApplyConfiguration(new OfficeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            builder.ApplyConfiguration(new TitleEntityTypeConfiguration());
        }
    }
}
