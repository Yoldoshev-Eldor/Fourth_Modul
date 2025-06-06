
using AvtoSalon.Repository.Services;
using AvtoSalon.Server.Configuration;
using AvtoSalon.Service.Services;

namespace AvtoSalon.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.ConfigureDatabase();

            builder.Services.AddScoped <IAvtoSalonRepo,AvtoSalonRepo> ();
            builder.Services.AddScoped<IAvtoSalonService, AvtoSalonService>();
            builder.Services.AddScoped <ICarRepo,CarRepo> ();
            builder.Services.AddScoped<ICarService, CarService>();



            var app = builder.Build();

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
    }
}
