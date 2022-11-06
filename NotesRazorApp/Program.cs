using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;

namespace NotesRazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(ConfigurationHelper.ConnectionString()));

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