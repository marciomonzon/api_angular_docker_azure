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
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Salary)
                .IsRequired();

            builder.Property(x => x.DateStartCompany)
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Ocuppation)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
