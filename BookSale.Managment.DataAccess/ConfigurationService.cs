using BookSale.Managment.DataAccess.DataAccess;
using BookSale.Managment.Domain.Entities;
using BookSale.Managment.Domain.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess
{
    public static class ConfigurationService
    {
        public static async void AutoMigration(this WebApplication webApplication)
        {
            using (IServiceScope scope = webApplication.Services.CreateScope())
            {
                BookStoreDbContext appContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();

                appContext.Database.EnsureCreated();
                await appContext.Database.MigrateAsync();
            }
        }

        public static async Task SeedData(this WebApplication webApplication, IConfiguration configuration)
        {
            using (IServiceScope scope = webApplication.Services.CreateScope())
            {
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                DefaultUser userDefault = configuration.GetSection("DefaultUser")?.Get<DefaultUser>();

                IdentityResult identityUser = await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = userDefault.UserName,
                    IsActive = true,
                    AccessFailedCount = 0,
                }, userDefault.Password);

                if (identityUser.Succeeded)
                {

                }

            }
        }
    }
}
