using MauiBankingExercise.ViewModels;
using MauiBankingExercise.Views;
using MauiBankingExercise.Services;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace MauiBankingExercise
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Set the culture to South Africa for proper currency formatting
            var culture = new CultureInfo("en-ZA");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    // Using Courier New as OCR-style font (monospace, resembles embossed text)
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register HttpClient for API service
            builder.Services.AddHttpClient();
            
            // Register both banking service implementations
            builder.Services.AddSingleton<BankingDatabaseService>();
            builder.Services.AddSingleton<BankingApiService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                return new BankingApiService(httpClient, "https://banking-api-3p7pr7x7j4wvc.azurewebsites.net");
            });
            
            // Choose which implementation to use for IBankingService
            // Set useApiService to true to use the API service, false for database service
            bool useApiService = true;
            
            if (useApiService)
            {
                builder.Services.AddSingleton<IBankingService>(provider => 
                    provider.GetRequiredService<BankingApiService>());
            }
            else
            {
                builder.Services.AddSingleton<IBankingService>(provider => 
                    provider.GetRequiredService<BankingDatabaseService>());
            }
            
            builder.Services.AddSingleton<CustomersViewModel>();
            builder.Services.AddTransient<CustomersView>();
            builder.Services.AddTransient<CustomerDashboardViewModel>();
            builder.Services.AddTransient<CustomerDashboardView>();
            builder.Services.AddTransient<AccountDetailsViewModel>();
            builder.Services.AddTransient<AccountDetailsView>();
            builder.Services.AddTransient<CreateTransactionViewModel>();
            builder.Services.AddTransient<CreateTransactionView>();
            return builder.Build();
        }
    }
}
