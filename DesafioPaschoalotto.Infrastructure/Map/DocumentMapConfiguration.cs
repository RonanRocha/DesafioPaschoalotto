using DesafioPaschoalotto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DesafioPaschoalotto.Infrastructure.Map
{
    public class DocumentMapConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                    .HasColumnType("varchar(10)")
                    .IsRequired();

            builder.Property(x => x.Value)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Document)
                   .HasForeignKey<Document>(x => x.UserId)
                   .IsRequired();
        }
    }
}
