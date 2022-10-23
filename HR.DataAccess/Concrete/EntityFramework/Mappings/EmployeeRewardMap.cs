using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EmployeeRewardMap : IEntityTypeConfiguration<EmployeeReward>
    {
        public void Configure(EntityTypeBuilder<EmployeeReward> builder)
        {
            builder.ToTable("EmployeeRewards");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedNever();

            builder.Property(r => r.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(r => r.RewardId).HasColumnName("RewardId");
            builder.Property(r => r.Date).HasColumnName("Date");

            builder.HasOne(r => r.Employee);
            builder.HasOne(r => r.Reward);
        }
    }
}
