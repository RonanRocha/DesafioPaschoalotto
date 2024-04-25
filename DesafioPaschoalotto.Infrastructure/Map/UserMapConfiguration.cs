using DesafioPaschoalotto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaschoalotto.Infrastructure.Map
{
    public class UserMapConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnType("varchar(255)")
                   .IsRequired();

            builder.Property(x => x.Title)
                   .HasColumnType("varchar(10)")
                   .IsRequired();

            builder.Property(x => x.Email)
                    .HasColumnType("varchar(255)")
                    .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.HasIndex(x => x.UserName)
                   .HasDatabaseName("ix_username")
                   .IsUnique();

            builder.HasIndex(x => x.Email)
                   .HasDatabaseName("ix_email")
                   .IsUnique();




        }
    }
}
