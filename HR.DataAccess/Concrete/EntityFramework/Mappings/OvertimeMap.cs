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
    public class OvertimeMap : IEntityTypeConfiguration<Overtime>
    {
        public void Configure(EntityTypeBuilder<Overtime> builder)
        {
            builder.ToTable("Overtimes");
            builder.HasKey(o=>o.Id);

            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o=>o.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(o => o.Date).HasColumnName("Date");
            builder.Property(o => o.HourCount).HasColumnName("HourCount");

            builder.HasOne(o=>o.Employee);
        }
    }
}
