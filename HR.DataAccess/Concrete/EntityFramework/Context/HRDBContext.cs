using Core.DataAccess.Concrete.EntityFramework.Mappings;
using Core.Entities.Concrete;
using HR.DataAccess.Concrete.EntityFramework.Mappings;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext : DbContext
    {
        #region DbSet
        public DbSet<CalendarDay> CalendarDays { get; set; }

        #endregion
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarDayMap());
        }
    }
}
