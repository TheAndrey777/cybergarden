using Microsoft.AspNetCore.Authentication.Cookies;

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
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/login");
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
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