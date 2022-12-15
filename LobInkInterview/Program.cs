
using LobInkInterview.Config;
using LobInkInterview.DataAccess;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Repositories;
using LobInkInterview.Services;
using LobInkInterview.Services.Interfaces;

namespace LobInkInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var appSettings = new AppSettings();
            builder.Configuration.Bind(appSettings);

            // Add services to the container.
            var dbContext = new DBContext(appSettings.MongoDB);
            builder.Services.AddSingleton<IAdventureDefinitionsRepository>(new AdventureDefinitionsRepository(dbContext));
            builder.Services.AddSingleton<IAdventuresRepository>(new AdventuresRepository(dbContext));
            builder.Services.AddSingleton<ISignatureHandler>(new SignatureHandler());

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