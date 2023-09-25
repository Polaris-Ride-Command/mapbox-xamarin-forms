using Android.App;
using Android.Content.PM;
using Android.OS;
//using Com.Mapbox.Mapboxsdk;
using MapboxMauiDemo.Services;
using Naxam.Controls.Forms;
using MapboxAccountManager = Com.Mapbox.Mapboxsdk.Mapbox;

namespace MapboxMauiDemo;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    MapView mapView;

    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);

        Com.Mapbox.Mapboxsdk.Mapbox.GetInstance(this, MapBoxService.AccessToken);
        Com.Mapbox.Mapboxsdk.Mapbox.Telemetry.SetDebugLoggingEnabled(true);

        System.Diagnostics.Debug.WriteLine("Mapbox version: " + Com.Mapbox.Mapboxsdk.BuildConfig.MAPBOX_VERSION_STRING);

        SetContentView(Resource.Layout.activity_main);
        //mapView = FindViewById<MapView>(Resource.Id.mapView);
        //mapView.OnCreate(bundle);
        //mapView.GetMapAsync(this);

    }
}

