using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Naxam.Mapbox.Platform.iOS;
using Naxam.Controls.Mapbox.Platform.iOS;
using Naxam.Controls.Forms;
using MapBoxQs.Services;

namespace MapBoxQs.iOS
{
    public static class MauiProgram
    {
        public static MauiAppBuilder builder;
        public static MauiAppBuilder Builder
        {
            get
            {
                if (builder == null)
                {
                    builder = MauiApp.CreateBuilder();
                }

                return builder;
            }
        }

        public static MauiApp CreateMauiApp()
        {
            var build = Builder;
            build.UseMauiApp<App>()
                .UseMauiCompatibility()
                .UseMauiCommunityToolkit()
                .UseFFImageLoading()
                .UseNaxamFormsiOS();

            Mapbox.MGLAccountManager.AccessToken = MapBoxService.AccessToken;

            return builder.Build();
        }
    }
}