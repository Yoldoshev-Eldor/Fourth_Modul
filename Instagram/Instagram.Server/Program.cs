
using Instagram.Bll.Services;
using Instagram.Repository.Services;
using Instagram.Server.Configurations;

namespace Instagram.Server
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

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IAccauntRepository, AccauntRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

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
