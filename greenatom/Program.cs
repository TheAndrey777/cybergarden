using greenatom.Models;
using greenatom.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace greenatom ;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/login")
//                 .AddOAuth("google", options =>
//                 {
//                     options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//                     options.ClientId = "703398525491-4sec9hr5anl562tgad451ejsj9vi30ej.apps.googleusercontent.com";
//                     options.ClientSecret = "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";
//                     options.SaveTokens = false;
//                     options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/auth";
//                     options.TokenEndpoint = "https://oauth2.googleapis.com/token";
//                     options.CallbackPath = "/redirect";
//                     options.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
//                     //options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token";
//                     /*options.Events.OnCreatingTicket = async context =>
//                      {
//
//                      };*/
//                 })
                .AddGoogle(options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.ClientId = "703398525491-4sec9hr5anl562tgad451ejsj9vi30ej.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.SaveTokens = false;
                    options.CallbackPath = "/redirect";
                    options.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
                })
                ;

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