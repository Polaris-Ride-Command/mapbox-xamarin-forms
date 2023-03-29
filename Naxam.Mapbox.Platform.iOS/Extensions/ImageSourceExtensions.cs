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
            //var handler =  IImageSourceHandler  (source);
            var handler = source.Handler.MauiContext;


            return source.GetPlatformImageAsync(handler).Result.Value;
        }
    }
}