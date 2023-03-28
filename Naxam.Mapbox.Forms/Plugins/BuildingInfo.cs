using System;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Naxam.Mapbox
{
    public class BuildingInfo
    {
        public Color Color { get; set; } = Colors.LightGray;

        public float Opacity { get; set; } = 0.6f;

        public float MinZoomLevel { get; set; } = 15f;

        public bool IsVisible { get; set; }

        public string AboveLayerId { get; set; }
    }
}

