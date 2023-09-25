using Android.Content;
using Com.Mapbox.Mapboxsdk;
using MapboxMauiDemo.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
#if IOS
using Naxam.Mapbox.Platform.iOS;
#endif

#if ANDROID
using Naxam.Mapbox.Platform.Droid;
using MapboxAccountManager = Com.Mapbox.Mapboxsdk.Mapbox;
#endif

namespace MapboxMauiDemo;

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
			})
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android
                    .OnCreate((activity, bundle) =>
                    {
                        LogEvent(nameof(AndroidLifecycle.OnCreate));
                        MapboxAccountManager.GetInstance(Platform.AppContext, MapBoxService.AccessToken);
                        //Mapbox.AccessToken = MapBoxService.AccessToken;
                        Com.Mapbox.Mapboxsdk.Mapbox.Telemetry.SetDebugLoggingEnabled(true);
                        System.Diagnostics.Debug.WriteLine("Mapbox version: " + Com.Mapbox.Mapboxsdk.BuildConfig.MAPBOX_VERSION_STRING);
                    }));
#endif
                static bool LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    return true;
                }
            }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if IOS
        Mapbox.MGLAccountManager.AccessToken = MapBoxService.AccessToken;
        builder.UseNaxamFormsiOS();

#endif

#if ANDROID
        //Mapbox.AccessToken = MapBoxService.AccessToken;
        //Mapbox.GetInstance(Platform.AppContext, MapBoxService.AccessToken);
        //Com.Mapbox.Mapboxsdk.Mapbox.Telemetry.SetDebugLoggingEnabled(true);
        builder.UseNaxamFormsDroid();
#endif

        return builder.Build();
	}
}

