using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(b => b.Description)
                .HasMaxLength(1000);
            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
