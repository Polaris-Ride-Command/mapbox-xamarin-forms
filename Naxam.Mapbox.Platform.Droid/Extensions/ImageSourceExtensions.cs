using System;
using Android.Content;
using Android.Graphics;
using Com.Mapbox.Mapboxsdk.Utils;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Naxam.Mapbox.Platform.Droid.Extensions
{
    public static class ImageSourceExtensions
    {
        public static Bitmap GetBitmap(this ImageSource source, Context context)
        {
            //var handler =  Xamarin.Forms.Internals.Registrar.Registered
            //    .GetHandlerForObject<IImageSourceHandler>(source);

            //return handler?
            //    .LoadImageAsync(source, context).Result;

            var handler = Microsoft.Maui.Controls.Internals.Registrar.Registered
                .GetHandlerForObject<IImageSourceHandler>(source);


            return handler?.LoadImageAsync(source, context).Result;
        }
    }
}