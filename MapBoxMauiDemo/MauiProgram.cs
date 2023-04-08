using MapboxMauiDemo.Services;
using Microsoft.Extensions.Logging;
using Naxam.Mapbox.Platform.iOS;

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

        return builder.Build();
	}
}

