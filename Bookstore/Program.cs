using Bookstore.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookstore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // connection configration

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");


            // DbContext Configuration
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ConnectionStringVar));

            var app = builder.Build();

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

			app.MapControllerRoute(
				 name: "default",
				 pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
        }
    }
}
