using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

using Server.Models;
using Server.Data;
using Server.Repository;
using Server.Interfaces;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<Seed>();

            builder.Services.AddScoped<IRepository<Person>, PeopleRepository>();
            builder.Services.AddScoped<IRepository<Class>, ClassesRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

            // Build App
            var app = builder.Build();

            // Seed Data
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                SeedData(app);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<Seed>();
                service.SeedData();
            }
        }
    }
}
