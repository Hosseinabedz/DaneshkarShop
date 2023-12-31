using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Data.Repositories;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DaneshkarShop.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region Builder
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DaneshkarDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("DaneshkarDbContext")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            #endregion
            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                // Add Cookie settings
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                }); 
            #endregion
            #region App Services
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
                name: "MyAreas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); ;

            app.Run();
            #endregion


        }
    }
}