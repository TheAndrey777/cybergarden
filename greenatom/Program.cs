using AspNet.Security.OAuth.Discord;
using AspNet.Security.OAuth.Vkontakte;
using greenatom.Models;
using greenatom.Services;
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
                    options.Scope.Add("email");
                    options.TokenEndpoint = GoogleDefaults.TokenEndpoint;
                    options.AuthorizationEndpoint = GoogleDefaults.AuthorizationEndpoint;
                    options.UserInformationEndpoint = GoogleDefaults.UserInformationEndpoint;
                    options.SaveTokens = true;
                })
                .AddVkontakte(VkontakteAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = "51487231";
                    options.ClientSecret = "KrlM6g70JYVqiCcbiGRo";
                    options.Scope.Add("email");
                    options.TokenEndpoint = VkontakteAuthenticationDefaults.TokenEndpoint;
                    options.AuthorizationEndpoint = VkontakteAuthenticationDefaults.AuthorizationEndpoint;
                    options.UserInformationEndpoint = VkontakteAuthenticationDefaults.UserInformationEndpoint;
                    options.SaveTokens = true;
                })
                .AddDiscord(DiscordAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = "1046179805365813268";
                    options.ClientSecret = "ZgApM5iyjRTyn8xewUpkd5Woy-5yXcEI";
                    options.Scope.Add("email");
                    options.TokenEndpoint = DiscordAuthenticationDefaults.TokenEndpoint;
                    options.AuthorizationEndpoint = DiscordAuthenticationDefaults.AuthorizationEndpoint;
                    options.UserInformationEndpoint = DiscordAuthenticationDefaults.UserInformationEndpoint;
                    options.SaveTokens = true;
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