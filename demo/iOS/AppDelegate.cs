using System;
using Foundation;
using Shiny.Net.Http;
using UIKit;
using Shiny.Jobs;
using MapBoxQs.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;

namespace MapBoxQs.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            Mapbox.MGLAccountManager.AccessToken = MapBoxQs.Services.MapBoxService.AccessToken;
            //new Naxam.Controls.Mapbox.Platform.iOS.MapViewRenderer();

            return base.FinishedLaunching(app, options);
        }

        //public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        //    => JobManager.OnBackgroundFetch(completionHandler);


        //public override void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, Action completionHandler)
        //    => HttpTransferManager.SetCompletionHandler(sessionIdentifier, completionHandler);
    }
}
