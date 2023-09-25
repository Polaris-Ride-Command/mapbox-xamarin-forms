
using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Mapbox.Mapboxsdk.Maps;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Geometry;
using static Com.Mapbox.Mapboxsdk.Maps.MapboxMap;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Graphics;
using MapBoxQs.Views;
namespace MapBoxQs.Droid
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //new Com.Facebook.Soloader.SoLoader();
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            Com.Mapbox.Mapboxsdk.Mapbox.GetInstance(this, MapBoxQs.Services.MapBoxService.AccessToken);
            Com.Mapbox.Mapboxsdk.Mapbox.Telemetry.SetDebugLoggingEnabled(true);


            System.Diagnostics.Debug.WriteLine("Mapbox version: " + Com.Mapbox.Mapboxsdk.BuildConfig.MAPBOX_VERSION_STRING);

            //Shiny.AndroidShinyHost.Init(
            //    this.Application,
            //    new MyStartup()
            //);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //CrossCurrentActivity.Current.Init(this, savedInstanceState);
            //LoadApplication(new App());

            //Shiny.Notifications.NotificationManager.TryProcessIntent(this.Intent);
            //SetContentView(Resource.Layout.activity_main);
            //mapView = (MapView)FindViewById(Resource.Id.mapView);
            //mapView.OnCreate(savedInstanceState);
            //mapView.GetMapAsync(new MapReady(this));
            //mapView.OffsetTopAndBottom(0);

        }

        //protected override void OnNewIntent(Intent intent)
        //{
        //    base.OnNewIntent(intent);
        //    //Shiny.Notifications.NotificationManager.TryProcessIntent(intent);
        //}

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    Shiny.AndroidShinyHost.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        //    Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}
