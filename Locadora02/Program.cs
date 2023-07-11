using Locadora02.Data;
using Microsoft.EntityFrameworkCore;
namespace Locadora02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

            builder.Services.AddDbContext<FilmeContext>
                (opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Policy1",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200",
                                            "https://localhost:7070/Filme",
                                            "https://http.cat/status/425",
                                            "https://localhost:7070/Filme/PostarGeneros")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}