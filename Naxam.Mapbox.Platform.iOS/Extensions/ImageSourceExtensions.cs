using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Platform;

namespace Naxam.Mapbox.Platform.iOS.Extensions
{
    public static class ImageSourceExtensions
    {
        public static UIImage GetImage(this ImageSource source)
        {

            /*** old xamarin code
             * var handler =  Xamarin.Forms.Internals.Registrar.Registered
                .GetHandlerForObject<IImageSourceHandler>(source);

            return handler?
                .LoadImageAsync(source).Result;
            ***/


            var handler = Microsoft.Maui.Controls.Internals.Registrar.Registered
                .GetHandlerForObject<IImageSourceHandler>(source);


            return handler?.LoadImageAsync(source).Result;
        }
    }
}