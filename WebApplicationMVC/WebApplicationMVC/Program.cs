using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using WebApplicationMVC.Data;
using WebApplicationMVC.Services;
namespace WebApplicationMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("WebApplicationMVCContext")
                                      ?? throw new InvalidOperationException("Connection string 'WebApplicationMVCContext' not found.");
            builder.Services.AddDbContext<WebApplicationMVCContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            var enUS = new CultureInfo("en-US");
            var localizations = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = [enUS],
                SupportedUICultures = [enUS]
            };

            app.UseRequestLocalization(localizations);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Dependency injection for services
            var scope = app.Services.CreateScope();
            var seedingService = scope.ServiceProvider.GetService<SeedingService>();
            seedingService.Seed();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
