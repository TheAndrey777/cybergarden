using greenatom.Models;
using greenatom.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace greenatom ;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(
                o => { o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; })
                .AddCookie(c => c.LoginPath = "/login")
                .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = @"140171481243-8sbr1e1lctf5ir09luflhja1j59u5qpt.apps.googleusercontent.com";
                    options.ClientSecret = @"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";
                    options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                    options.Scope.Add("email");
                });


            builder.Services.AddAuthorization();

            builder.Services.AddHttpClient();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("Database"));
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }