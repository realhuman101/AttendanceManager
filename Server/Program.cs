using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

using Server.Models;
using Server.Data;
using Server.Repository;
using Server.Interfaces;
using Server.Overrides;
using Server.Controllers;

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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication()
                .AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);

            builder.Services.AddDbContext<DataContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentityCore<User>(config =>
                    {
                        config.SignIn.RequireConfirmedEmail = false;
                    })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();

            // Build App
            var app = builder.Build();

            app.MapControllers();

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

            app.Run();
        }
    }
}
