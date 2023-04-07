using Microsoft.Extensions.Logging;

#if IOS
using Naxam.Mapbox.Platform.iOS;
#endif

namespace MapBoxMauiDemo;

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

#if IOS
			builder.UseNaxamFormsiOS();
			new Naxam.Controls.Mapbox.Platform.iOS.MapViewRenderer();
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}

