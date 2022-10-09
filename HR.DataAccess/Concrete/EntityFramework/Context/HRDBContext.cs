using HR.DataAccess.Concrete.EntityFramework.Mappings;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext: DbContext
    {
        #region DbSets

        public DbSet<State> States { get; set; }
        public DbSet<UserKey> UserKeys { get; set; }

        #endregion

        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new UserKeyMap());
        }
    }
}
