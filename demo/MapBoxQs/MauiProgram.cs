using System;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using MapBoxQs.Views;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Shiny.Net.Http;

namespace MapBoxQs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
                .UseFFImageLoading()
                .UseMauiCommunityToolkit()
                .RegisterShinyServices()
                .RegisterAppThings();

            return builder.Build();
        }


        public static MauiApp App { get; private set; }
        public static IServiceProvider Services
            => App.Services;

        static MauiAppBuilder RegisterShinyServices(this MauiAppBuilder builder)
        {
            var s = builder.Services;

            // shiny.net.http
            s.AddShinyService<AppStartup>();
            s.AddHttpTransfers<MyTransferDelegate>();

            return builder;
        }

        static MauiAppBuilder RegisterAppThings(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MapBoxQsPage>();
            builder.Services.AddTransient<StylesDefaultPage>();

            return builder;
        }
    }
}

