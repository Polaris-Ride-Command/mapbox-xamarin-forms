using Naxam.Controls.Forms;
using Naxam.Mapbox;

namespace MapboxMauiDemo;

public partial class StylesDefaultPage : ContentPage
{
	public StylesDefaultPage()
	{
		InitializeComponent();

        Title = "Default Styles";

        map.Center = new LatLng(21.028511, 105.804817);
        map.ZoomLevel = 12;

        map.MapStyle = MapStyle.LIGHT;
    }
}
