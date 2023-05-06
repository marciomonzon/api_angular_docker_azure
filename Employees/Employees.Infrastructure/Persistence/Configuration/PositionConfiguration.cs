using Employees.Domain.Entities.AggregateEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Persistence.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasColumnType("varchar")
            .HasMaxLength(200);

            builder.Property(c => c.OccupationType)
                   .HasConversion<int>();

            builder.Property(x => x.DateCreated)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        }
    }
}
