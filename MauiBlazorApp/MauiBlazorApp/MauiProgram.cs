using MauiBlazorApp.Services;
using MauiBlazorApp.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MauiBlazorApp
{
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
                });

            // Add device-specific services used by the MauiBlazorApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            //+>>20250105
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            builder.Configuration.AddConfiguration(config);

            var baseUri = builder.Configuration["ApiSettings:BaseUri"];
            if (string.IsNullOrEmpty(baseUri))
            {
                throw new InvalidOperationException("API Base URI is not configured.");
            }
            builder.Services.AddSingleton<IDeutschAdjSuffixService, DeutschAdjSuffixService>();
            builder.Services.AddHttpClient<IDeutschAdjSuffixService, DeutschAdjSuffixService>(client =>
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromSeconds(30);
            });
            //+<<20250105
            return builder.Build();
        }
    }
}
