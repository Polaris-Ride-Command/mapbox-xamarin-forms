using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Hosting;
using Naxam.Controls.Forms;
using Naxam.Controls.Mapbox.Platform.Droid;

namespace Naxam.Mapbox.Platform.Droid
{
	public static class MauiAppBuilderExtensions
	{
        public static MauiAppBuilder UseNaxamFormsDroid(this MauiAppBuilder builder)
        {
            builder
                .UseMauiCompatibility()
                .ConfigureMauiHandlers((handlers) =>
                {
                    handlers.AddCompatibilityRenderer(typeof(MapView), typeof(MapViewRenderer));

                });

            builder.Services.RegisterServices();

            return builder;
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IOfflineStorageService, OfflineStorageService>();

            services.AddSingleton<IMapFunctions, MapViewRenderer>();
        }
    }
}

