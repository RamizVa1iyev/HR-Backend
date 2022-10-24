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
    public class RewardMap : IEntityTypeConfiguration<Reward>
    {
        public void Configure(EntityTypeBuilder<Reward> builder)
        {
            builder.ToTable("Rewards");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedNever();

            builder.Property(r => r.Name).HasColumnName("Name");
            builder.Property(r => r.Amount).HasColumnName("Amount");
        }
    }
}
