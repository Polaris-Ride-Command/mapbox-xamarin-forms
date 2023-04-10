using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Hosting;
using Naxam.Controls.Forms;
using Naxam.Controls.Mapbox.Platform.iOS;

namespace Naxam.Mapbox.Platform.iOS
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseNaxamFormsiOS(this MauiAppBuilder builder)
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

