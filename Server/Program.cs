using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Server.Models;
using Server.Data;
using Server.Repository;
using Server.Interfaces;
using Server.Overrides;
using Server.Controllers;
using System.Data;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddJsonOptions(options => {
                                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                            })
                            .AddApplicationPart(typeof(ClassesController).Assembly);

            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
            builder.Services.AddScoped<IClassesRepository, ClassesRepository>();

            builder.Services.AddTransient<UserManager<User>>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();

            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<DataContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, IdentityRole>(config =>
                    {
                        config.SignIn.RequireConfirmedEmail = false;
                    })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();

            // Build App
            var app = builder.Build();

            app.MapControllers();

            IMemoryCache cache = app.Services.GetRequiredService<IMemoryCache>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapIdentityApiFilterable<User>(new IdentityApiEndpointRouteBuilderOptions()
            {
                ExcludeRegisterPost = true,
                ExcludeLoginPost = false,
                ExcludeRefreshPost = false,
                ExcludeConfirmEmailGet = true,
                ExcludeResendConfirmationEmailPost = true,
                ExcludeForgotPasswordPost = false,
                ExcludeResetPasswordPost = false,
                ExcludeManageGroup = true,
                Exclude2faPost = true,
                ExcludegInfoGet = true,
                ExcludeInfoPost = true,
            });

            seedRoles(app);

            app.Run();
        }

        public static async void seedRoles(WebApplication app)
        {
            // Seed roles
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Manager", "Staff" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

                // Set up user
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var admin = await userManager.FindByEmailAsync("test@gmail.com");
                if (!await userManager.IsInRoleAsync(admin, "Admin"))
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
