using Microsoft.Maui;
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Platform;

namespace MapBoxQs
{
    public partial class MapBoxQsPage : ContentPage
    {
        public MapBoxQsPage()
        {
            var viewModel = new MainPageViewModel(Navigation);
//#if iOS
//            SetUseSafeArea(true);
//#endif
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
