using CommunityToolkit.Maui;
using FilmDB.Core.Services;
using FilmDB.Core.ViewModels;
using Microsoft.Extensions.Logging;

namespace FilmDB.Gui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            System.Diagnostics.Debug.WriteLine("Path:");
            string path = FileSystem.Current.AppDataDirectory;
            string filename = "films.sqlite";

            string fullpath = System.IO.Path.Combine(path, filename);
            System.Diagnostics.Debug.WriteLine(fullpath);

            builder.Services.AddSingleton<IRepository>(new FilmRepository(fullpath));
            builder.Services.AddSingleton<IRandomMovie>(new RandomMovie(fullpath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
