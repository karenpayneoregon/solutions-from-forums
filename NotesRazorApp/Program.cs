using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using Serilog;
using SeriLogThemesLibrary;
using static System.DateTime;

namespace NotesRazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            builder.Host.UseSerilog((ctx, lc) => lc
                .Filter.ByExcluding(logEvent =>
                {
                    if (logEvent.Level != Serilog.Events.LogEventLevel.Information)
                        return false;

                    if (!logEvent.Properties.TryGetValue("SourceContext", out var sourceContext))
                        return false;

                    var sourceContextStr = sourceContext.ToString();
                    return !sourceContextStr.Contains("System.Net.Http.HttpClient") &&
                           !sourceContextStr.Contains("Request starting HTTP/2 GET https://localhost") &&
                           !sourceContextStr.Contains("_framework/aspnetcore-browser-refresh.js") &&
                           !sourceContextStr.Contains("browserLink");
                })
                .WriteTo.Console(theme: SeriLogCustomThemes.Theme1())
                .WriteTo.File(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now:yyyy-MM-dd}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}"));




            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(ConfigurationHelper.ConnectionString())
                    .EnableSensitiveDataLogging());

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}