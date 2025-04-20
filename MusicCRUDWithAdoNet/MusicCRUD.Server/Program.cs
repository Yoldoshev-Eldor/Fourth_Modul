
using MsicCRUD.DataAccess.Entity;
using MusicCRUD.Repostory.Services;
using MusicCRUD.Service;

namespace MusicCRUD.Server
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



            builder.Services.AddScoped<IMusicService, MusicService>();
            //builder.Services.AddScoped<IMusicRepostory, MusicRepostory>();
            //builder.Services.AddSingleton<MainContext>();
            //builder.Services.AddScoped<IMusicRepostory, MusicRepostoryFile>();
            builder.Services.AddScoped<IMusicRepostory, MusicRepostoryAdoNet>();






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
