using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class DiseaseBulletenMap: IEntityTypeConfiguration<DiseaseBulleten>
    {
        public void Configure(EntityTypeBuilder<DiseaseBulleten> builder)
        {

            builder.ToTable("DiseaseBulletens");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedNever();

            builder.Property(d => d.ClinicName).HasColumnName("ClinicName");
            builder.Property(d => d.StartDate).HasColumnName("StartDate");
            builder.Property(d => d.EndDate).HasColumnName("EndDate");
            builder.Property(d => d.Note).HasColumnName("Note");
            builder.Property(d => d.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(d => d.CreateDate).HasColumnName("CreateDate");
            builder.Property(d => d.DocumentNumber).HasColumnName("DocumentNumber");
            builder.Property(d => d.PayPercent).HasColumnName("PayPercent");

            builder.HasOne(d => d.Employee);
            
        }
    }
}
