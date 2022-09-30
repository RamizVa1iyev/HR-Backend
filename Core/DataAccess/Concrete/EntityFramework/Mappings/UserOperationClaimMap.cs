using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims");
            builder.HasKey(u => u.Id);

            //builder.Property(u=>u.Id).ValueGeneratedNever();
            builder.Property(u => u.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(u => u.UserId).HasColumnName("UserId");
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
        }
    }
}
