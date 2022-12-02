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
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<DiseaseBulleten> DiseaseBulletens { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<EmployeeReward> EmployeeRewards { get; set; }
        public DbSet<UserKey> UserKeys { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Duty> Duties { get; set; }

        #endregion

        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarDayMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new OvertimeMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new UserKeyMap());
            modelBuilder.ApplyConfiguration(new DiseaseBulletenMap());
            modelBuilder.ApplyConfiguration(new VacationMap());
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new RewardMap());
            modelBuilder.ApplyConfiguration(new EmployeeRewardMap());
            modelBuilder.ApplyConfiguration(new ContractMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
        }
    }
}
