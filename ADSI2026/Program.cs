using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Domain.Services;
using MVC.Domain.Services.Interfaces;

namespace ADSI2026
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region SQL SERVER
            builder.Services.AddDbContext<NorthwindContext>(opt =>
               {
                   opt.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
               });
            #endregion

            #region Inyectores de dependencia
            builder.Services.AddTransient<ICustomerServices, CustomerServices>();            
            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<ISupplierServices, SupplierServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();

            #endregion


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
