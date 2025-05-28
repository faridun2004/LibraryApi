using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data.Configuration
{
    public class FavoriteBookConfiguration : IEntityTypeConfiguration<FavoriteBook>
    {
        public void Configure(EntityTypeBuilder<FavoriteBook> builder)
        {
            builder.HasKey(fb => fb.Id);
            builder.HasOne(fb => fb.Book)
                .WithMany()
                .HasForeignKey(fb => fb.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(fb => fb.User)
                .WithMany(u => u.FavoriteBooks)
                .HasForeignKey(fb => fb.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
