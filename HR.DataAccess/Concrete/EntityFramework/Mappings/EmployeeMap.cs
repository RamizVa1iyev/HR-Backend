using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Surname).HasColumnName("Surname");
            builder.Property(e => e.FatherName).HasColumnName("FatherName");
            builder.Property(e => e.FinCode).HasColumnName("FinCode");
            builder.Property(e => e.Address).HasColumnName("Address");
            builder.Property(e => e.Phone).HasColumnName("Phone");
            builder.Property(e => e.Gender).HasColumnName("Gender");
            builder.Property(e => e.BirthDay).HasColumnName("BirthDay");
            builder.Property(e => e.DailyWorkHour).HasColumnName("DailyWorkHour");
            builder.Property(e => e.OperatingMode).HasColumnName("OperatingMode");
            builder.Property(e => e.Status).HasColumnName("Status");
            builder.Property(e => e.UserId).HasColumnName("UserId");
            builder.Property(e => e.DutyId).HasColumnName("DutyId");

            builder.HasMany(e => e.DiseaseBulletens);
        }
    }
}
