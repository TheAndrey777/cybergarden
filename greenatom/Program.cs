using Microsoft.Extensions.FileProviders;
using greenatom.Models;
using greenatom.Services;

namespace greenatom;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("Database"));
        builder.Services.AddSingleton<DatabaseService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseStaticFiles();

        app.UseFileServer(new FileServerOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "client")),
            //RequestPath = "/",
            EnableDirectoryBrowsing = true
        });

        app.MapControllers();

        app.Run();
    }
}