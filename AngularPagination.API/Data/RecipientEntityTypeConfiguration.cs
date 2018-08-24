using AngularPagination.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularPagination.API.Data
{
    public class RecipientEntityTypeConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Recipient> builder)
        {
            builder.ToTable("Recipients");

            builder.HasKey(x => x.RecipientId);

            builder.Property(x => x.RecipientName)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}