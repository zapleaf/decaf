using decaf.Application.Extensions;
using decaf.Blazor.Components;
using decaf.Blazor.Services;
using decaf.Infrastructure.Extension;

namespace decaf.Blazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // You could get connection string from appsetting and pass it for DbContext or 
        // as in this case, pass the entire config to our Infrastructure service
        // Goes to the AddInfrastructure method in ServiceCollectionExtension class
        builder.Services.AddInfrastructure(builder.Configuration);

        // Services Specifically for the UI
        builder.Services.AddSingleton<NavItemService>();
        builder.Services.AddScoped<UserSettingsService>();

        // Goes to the AddApplication method in ServiceCollectionExtension class
        builder.Services.AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
