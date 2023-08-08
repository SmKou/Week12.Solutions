global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.Linq;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Library.Models;

namespace Library;

class Program
{
    static void Main(string[] args)
    {

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<LibraryContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(
                builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
            )
            )
        );

        builder.Services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<LibraryContext>()
            .AddDefaultTokenProviders();
            .AddRoles<IdentityRole>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            /*  Default password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            */
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 0;
            options.Password.RequiredUniqueChars = 0;
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Librarian"))
        });
        builder.Services.AddAuthentication();

        WebApplication app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            db.Database.Migrate();

            var roleManager = scope.ServiceProvider.GetRequiredService<roleManager<IdentityRole>>();

            string[] roleNames = { "Librarian" };
            foreach (string role in roleNames)
            {
                bool roleExists = roleManager.RoleExistsAsync(role).Result;
                if (!roleExists)
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
            }

            DataInitializer.Init(db);
        }

        // app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
