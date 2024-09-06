
using BookSale.Managment.DataAccess;
using BookSale.Managment.DataAccess.Configuration;
using BookSale.Managment.DataAccess.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình các dịch vụ
builder.Services.AddRazorPages();
builder.Services.RegisterDb(builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

var app = builder.Build();

await app.AutoMigration();

await app.SeedData(builder.Configuration);

// Cấu hình pipeline HTTP request
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

int timeOutCacheStaticFiles = 60 * 60;

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = cg =>
    {
        cg.Context.Response.Headers.Append("Cache-Control", $"public, max-age={timeOutCacheStaticFiles}");
    }
});

app.UseRouting();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AdminRouting",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
