using DesafioPaschoalotto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaschoalotto.Infrastructure.Map
{
    public class LocationMapConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street)
                   .IsRequired();

            builder.Property(x => x.Number)
                   .HasColumnType("integer")
                   .IsRequired();

            builder.Property(x => x.PostCode)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(x => x.Country)
                   .IsRequired();

            builder.Property(x => x.City)
                  .IsRequired();

            builder.Property(x => x.State)
                  .IsRequired();

            builder.Property(x => x.Latitude)
                 .IsRequired();

            builder.Property(x => x.Longitude)
                   .IsRequired();

            builder.Property(x => x.TimeZone)
                   .IsRequired();

            builder.Property(x => x.TimeZoneOffSet)
                   .HasColumnType("varchar(20)")
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Location)
                   .HasForeignKey<Location>(x => x.UserId)
                   .IsRequired();
        }
    }
}
