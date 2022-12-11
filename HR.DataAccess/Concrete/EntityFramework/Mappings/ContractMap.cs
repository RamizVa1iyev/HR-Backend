using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ContractMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();


            builder.Property(c => c.ContractStartDate).HasColumnName("ContractStartDate");
            builder.Property(c => c.ContractEndDate).HasColumnName("ContractEndDate");
            builder.Property(c => c.ContractNumber).HasColumnName("ContractNumber");
            builder.Property(c => c.EmployeeId).HasColumnName("EmployeeId");

            //builder.HasOne(d => d.Employee);
        }
    }
}
