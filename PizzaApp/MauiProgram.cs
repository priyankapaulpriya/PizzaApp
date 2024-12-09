using PizzaApp.Services;
using PizzaApp.ViewModels;
using PizzaApp.Pages;
using Microsoft.Maui.Storage;

namespace PizzaApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // SQLite Database Path
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PizzaApp.db");

        // Register services
        builder.Services.AddSingleton(new DatabaseService(dbPath));
        builder.Services.AddSingleton<ApiService>();

        // Register ViewModels
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<PizzaDetailsViewModel>();

        // Register Pages
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<PizzaDetailsPage>();

        return builder.Build();
    }
}
