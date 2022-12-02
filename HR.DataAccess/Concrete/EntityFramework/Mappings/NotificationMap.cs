using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.NotificationType).HasColumnName("NotificationType");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.RecordId).HasColumnName("RecordId");
        }
    }
}
