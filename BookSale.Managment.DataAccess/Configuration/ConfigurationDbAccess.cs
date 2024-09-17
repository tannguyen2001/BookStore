using BookSale.Managment.DataAccess.DataAccess;
using BookSale.Managment.Domain.Entities;
using BookSale.Managment.Domain.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.Configuration
{
    public static class ConfigurationDbAccess
    {
        public static async Task AutoMigration(this WebApplication webApplication)
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
            try
            {
                using (IServiceScope scope = webApplication.Services.CreateScope())
                {
                    UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                    string roleDefault = configuration.GetSection("DefaultRole")?.Get<string>() ?? "SuperAdmin";

                    //check role
                    bool isExitsRole = await roleManager.RoleExistsAsync(roleDefault);
                    if (!isExitsRole)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleDefault));
                    }

                    DefaultUser userDefault = configuration.GetSection("DefaultUser")?.Get<DefaultUser>() ?? new DefaultUser();
                    ApplicationUser userCheck = await userManager.FindByNameAsync(userDefault.UserName);

                    if (userCheck == null)
                    {
                        ApplicationUser user = new ApplicationUser
                        {
                            UserName = userDefault.UserName,
                            Fullname = "Nguyen Van Tan",
                            Email = userDefault.Email,
                            Address = "Sóc Sơn",
                            IsActive = true,
                            AccessFailedCount = 0,
                            NormalizedEmail = userDefault.Email.ToUpper(),
                        };


                        IdentityResult identityUser = await userManager.CreateAsync(user, userDefault.Password);

                        if (identityUser.Succeeded)
                        {
                            //add role
                            await userManager.AddToRoleAsync(user, roleDefault);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
