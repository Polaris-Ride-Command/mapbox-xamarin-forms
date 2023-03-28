using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Naxam.Mapbox.Sources
{
    public class MapboxImageSource : Source
    {
        public ImageSource Source { get; private set; }

        public LatLngQuad Coordinates { get;  private set; }

        public MapboxImageSource(string id, LatLngQuad coordinates, ImageSource source)
        {
            Id = id;
            Coordinates = coordinates;
            Source = source;
        }
    }
}