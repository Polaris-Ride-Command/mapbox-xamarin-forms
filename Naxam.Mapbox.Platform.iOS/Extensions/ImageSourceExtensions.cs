using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Xamarin.Forms.Platform.iOS;

namespace Naxam.Mapbox.Platform.iOS.Extensions
{
    public static class ImageSourceExtensions
    {
        public static UIImage GetImage(this ImageSource source)
        {
            var handler =  Xamarin.Forms.Internals.Registrar.Registered
                .GetHandlerForObject<IImageSourceHandler>(source);

            return handler?
                .LoadImageAsync(source).Result;
        }
    }
}