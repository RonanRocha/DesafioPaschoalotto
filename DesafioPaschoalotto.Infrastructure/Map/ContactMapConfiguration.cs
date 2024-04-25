using DesafioPaschoalotto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaschoalotto.Infrastructure.Map
{
    public class ContactMapConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cell)
                   .IsRequired();

            builder.Property(x=> x.Phone)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Contact)
                   .HasForeignKey<Contact>(x => x.UserId)
                   .IsRequired();
        }
    }
}
