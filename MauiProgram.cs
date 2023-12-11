using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TecnologicoAppDani2.Service;
using TecnologicoAppDani2.Service.Interface;
using TecnologicoAppDani2.ViewModels;
using TecnologicoAppDani2.Views;




namespace TecnologicoAppDani2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<SignUpPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<ISignUpSignInService, SignUpSignInService>();
            return builder.Build();
        }
    }
}