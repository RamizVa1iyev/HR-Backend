using Core.DataAccess.Concrete.EntityFramework.Mappings;
using Core.Entities.Concrete;
using HR.DataAccess.Concrete.EntityFramework.Mappings;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext : DbContext
    {
        #region DbSet
        public DbSet<CalendarDay> CalendarDays { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DiseaseBulleten> DiseaseBulletens { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        #endregion

        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {            


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarDayMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new UserKeyMap());
            modelBuilder.ApplyConfiguration(new DiseaseBulletenMap());
            modelBuilder.ApplyConfiguration(new VacationMap());
        }
    }
}
