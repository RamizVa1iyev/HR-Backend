using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class VacationMap: IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable("Vacations");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedNever();

            builder.Property(d => d.StartDate).HasColumnName("StartDate");
            builder.Property(d => d.EndDate).HasColumnName("EndDate");
            builder.Property(d => d.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(d => d.ComeWorkTime).HasColumnName("ComeWorkTime");
            builder.HasOne(d => d.Employee);
        }
    }
}
