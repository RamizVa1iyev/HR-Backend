<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
=======
﻿using HR.DataAccess.Concrete.EntityFramework.Mappings;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
>>>>>>> origin/arzu-branch-1

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext : DbContext
    {
<<<<<<< HEAD
=======
        public DbSet<CalendarDay> CalendarDays { get; set; }
        public DbSet<Employee> Employees { get; set; }

>>>>>>> origin/arzu-branch-1
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {            

<<<<<<< HEAD
=======

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarDayMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
>>>>>>> origin/arzu-branch-1
        }
    }
}
