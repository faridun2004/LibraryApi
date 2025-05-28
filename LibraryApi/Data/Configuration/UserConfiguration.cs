using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(u => u.FavoriteBooks)
                .WithOne(fb => fb.User)
                .HasForeignKey(fb => fb.UserId);
        }
    }
}

