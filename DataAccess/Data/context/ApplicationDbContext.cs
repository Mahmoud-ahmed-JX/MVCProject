
using DataAccess.Models.EmployeeModule;
using DataAccess.Models.IdentityModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;


namespace DataAccess.Data.context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
                }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        }
}
