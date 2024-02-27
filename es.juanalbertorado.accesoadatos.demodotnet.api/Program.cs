
using es.juanalbertorado.accesoadatos.demodotnet.api.DDBB;
using es.juanalbertorado.accesoadatos.demodotnet.api.Repositories;
using es.juanalbertorado.accesoadatos.demodotnet.api.Services;
using Microsoft.EntityFrameworkCore;

namespace es.juanalbertorado.accesoadatos.demodotnet.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DemoDotNetDbContext>(options => options.UseInMemoryDatabase(Database));
            builder.Services.AddScoped<EstudianteCollectionRepository>();
            builder.Services.AddScoped<IEstudianteRepository, EstudianteDbRepository>();
            builder.Services.AddScoped<EstudianteService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

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
