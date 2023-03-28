using System.Timers;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Naxam.Mapbox.Expressions;
using Naxam.Mapbox.Layers;
using Naxam.Mapbox.Sources;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Xamarin.Forms.Xaml;

namespace MapBoxQs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtrusionRotation : ContentPage
    {
        public ExtrusionRotation()
        {
            InitializeComponent();

            map.Center = new LatLng(40.706, -74.011);
            map.MapStyle = MapStyle.DARK;
            map.ZoomLevel = 16;
            map.Pitch = 45;

            map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);
        }

        private void HandleStyleLoaded(MapStyle obj)
        {
            map.Functions.ShowBuilding(new BuildingInfo() {
                Color = Color.LightGray,
                Opacity = 0.6f,
                MinZoomLevel = 15,
                IsVisible = true
            });

            map.Functions.AnimateCamera(new CameraPosition(map.Center, map.ZoomLevel, map.Pitch, 0), 1000);
        }
    }
}