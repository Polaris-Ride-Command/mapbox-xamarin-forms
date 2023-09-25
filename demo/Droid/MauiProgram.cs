using System;
using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Naxam.Controls.Forms;
using Naxam.Mapbox.Platform.Droid;

namespace MapBoxQs.Droid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
                .UseMauiCommunityToolkit()
                .UseFFImageLoading()
                .UseNaxamFormsDroid();


            return builder.Build();
        }
    }
}

