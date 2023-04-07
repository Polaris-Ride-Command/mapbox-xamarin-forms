using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Naxam.Controls.Forms;
using Naxam.Mapbox;

namespace MapBoxMauiDemo;

public partial class StylesDefaultPage : ContentPage
{
	public StylesDefaultPage()
	{
		InitializeComponent();
        Title = "Default Style";

        map.Center = new LatLng(21.028511, 105.804817);
        map.ZoomLevel = 12;

        map.MapStyle = MapStyle.LIGHT;
    }
}
