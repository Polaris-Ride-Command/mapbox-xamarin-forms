﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Naxam.Mapbox.Layers
{
    public class BackgroundLayer : StyleLayer
    {
        public Color BackgroundColor { get; set; } = Color.White;

        public BackgroundLayer(string id, string sourceId) : base(id, sourceId)
        {
        }
    }
}
