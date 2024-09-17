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

namespace BookSale.Managment.Infrastructure.ConfigurationService
{
    public static class ConfigurationService
    {


        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionMySql")
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //services.AddDbContext<BookStoreDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient
        }

    }
}
