using System.Collections;
using System.Web;
using BugTrackerV1.Authorization;
using BugTrackerV1.Filters;
using BugTrackerV1.Handlers;
using BugTrackerV1.Interfaces;
using BugTrackerV1.Models;
using BugTrackerV1.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerV1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Регистрация сервисов
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("TracVw", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracVw")));
                options.AddPolicy("TracCr", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracCr")));
                options.AddPolicy("TracEd", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracEd")));
                options.AddPolicy("TracDel", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracDel")));
                options.AddPolicy("TracVwRep", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracVwRep")));
                options.AddPolicy("TracChTas", policy =>
                    policy.Requirements.Add(new PermissionRequirement("TracChTas")));
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Authentications/Authorization";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromDays(2);
                    options.SlidingExpiration = true;
                });

            builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            builder.Services.AddScoped<EnsureProjectSelectedFilter>();

            var app = builder.Build();
            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/error/404";
                    await next();
                }

                if (ctx.Response.StatusCode == 302)
                {
                    var logger = ctx.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogInformation("Перенаправление на URL: {Location}", ctx.Response.Headers["Location"]);
                }
            });

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboards}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "{controller=Authentications}/{action=Authorization}/{id?}");

                endpoints.MapControllerRoute(
                    name: "selectProject",
                    pattern: "{controller=Project}/{action=Index}/{id?}");
            });

            app.Run();

        }
    }
}
