using HR.DataAccess.Concrete.EntityFramework.Mappings;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext : DbContext
    {
        public DbSet<CalendarDay> CalendarDays { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarDayMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
        }
    }
}
