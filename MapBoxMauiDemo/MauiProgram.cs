using Android.Content;
using MapboxMauiDemo.Services;
using Microsoft.Extensions.Logging;
#if IOS
using Naxam.Mapbox.Platform.iOS;
#endif

#if ANDROID
using Naxam.Mapbox.Platform.Droid;
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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if IOS
        Mapbox.MGLAccountManager.AccessToken = MapBoxService.AccessToken;
        builder.UseNaxamFormsiOS();

#endif

#if ANDROID
        builder.UseNaxamFormsDroid();
#endif

		return builder.Build();
	}
}

