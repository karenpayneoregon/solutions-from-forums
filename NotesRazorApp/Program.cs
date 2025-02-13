using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using Serilog;
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
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                        "LogFiles",
                        $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
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