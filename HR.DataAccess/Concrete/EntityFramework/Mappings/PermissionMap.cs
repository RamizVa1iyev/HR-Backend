using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.PermissionType).HasColumnName("PermissionType");
            builder.Property(p => p.Count).HasColumnName("Count");
            builder.Property(p=>p.StartDate).HasColumnName("StartDate");
            builder.Property(p => p.EndDate).HasColumnName("EndDate");

            builder.HasOne(p=>p.Employee);
        }
    }
}
