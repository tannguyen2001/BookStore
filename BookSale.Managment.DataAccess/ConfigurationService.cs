using BookSale.Managment.DataAccess.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
            using (var scope = webApplication.Services.CreateScope())
            {
                var appContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();

                appContext.Database.EnsureCreated();
                await appContext.Database.MigrateAsync();
            }
        }
    }
}
