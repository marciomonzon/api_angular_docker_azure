using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Salary)
                   .IsRequired()
                   .HasPrecision(12, 2);

            builder.Property(x => x.DateStartCompany)
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(x => x.Ocuppation)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
