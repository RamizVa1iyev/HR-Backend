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
    public class CalendarDayMap : IEntityTypeConfiguration<CalendarDay>
    {
        public void Configure(EntityTypeBuilder<CalendarDay> builder)
        {

            builder.ToTable("CalendarDays");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Date).HasColumnName("Date");
            builder.Property(c=>c.DayType).HasColumnName("DayType");
        }
    }
}
