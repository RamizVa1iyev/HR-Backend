using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserSecretKeyMap : IEntityTypeConfiguration<UserSecretKey>
    {
        public void Configure(EntityTypeBuilder<UserSecretKey> builder)
        {
            builder.ToTable("UserSecretKeys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.SecretKey).HasColumnName("SecretKey");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.IsUsed).HasColumnName("IsUsed");
        }
    }
}
