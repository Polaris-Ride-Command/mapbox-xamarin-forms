using Foundation;
using Mapbox;
using UIKit;

namespace MapBoxMauiDemo;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        MGLAccountManager.AccessToken = "pk.eyJ1IjoibmF4YW10ZXN0IiwiYSI6ImNqNWtpaG1oYTJqZmQyd28yM2tsdDhucmEifQ.Zr35ENq9tziBBDAbdeU2dw";

        return true;
    }
}

