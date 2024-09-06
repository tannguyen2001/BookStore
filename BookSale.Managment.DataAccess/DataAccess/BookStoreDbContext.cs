using BookSale.Managment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookSale.Managment.DataAccess.DataAccess
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<BookCatalogue> BookCatalogue { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Catalogue> Catalogue { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Cấu hình bảng ApplicationUser
            builder.Entity<ApplicationUser>().ToTable("User");

            // Cấu hình bảng IdentityRole
            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
                // Thay thế nvarchar(max) bằng longtext để tương thích với MySQL
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");
            });

            // Cấu hình các bảng khác của Identity
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        }
    }
}
