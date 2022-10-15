using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims");
            builder.HasKey(o => o.Id);

            builder.Property(u => u.Id).ValueGeneratedNever();

            builder.Property(o => o.Name).HasColumnName("Name");
        }
    }
}
