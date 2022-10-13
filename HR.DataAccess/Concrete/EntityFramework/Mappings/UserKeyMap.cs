using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserKeyMap : IEntityTypeConfiguration<UserKey>
    {
        public void Configure(EntityTypeBuilder<UserKey> builder)
        {
            builder.ToTable("UserKeys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.SecretKey).HasColumnName("SecretKey");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.IsUsed).HasColumnName("IsUsed");
        }
    }
}
