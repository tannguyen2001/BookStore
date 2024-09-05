using BookSale.Managment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.DataAccess
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public BookStoreDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Book> Book { get; set; }
        public DbSet<BookCatalogue> BookCatalogue { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Catalogue> CartCatalogue { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        }
    }
}
