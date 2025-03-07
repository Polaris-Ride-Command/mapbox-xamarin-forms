﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Mapbox.Mapboxsdk.Annotations;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Naxam.Controls.Platform.Droid.Utils;
//using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Naxam.Mapbox.Platform.Droid
{
    using Platform = Microsoft.Maui.Controls.Compatibility.Platform.Android.Platform;

    public class ViewGroupContainer : ViewGroup
    {
        IVisualElementRenderer _child;

        public ViewGroupContainer(IntPtr p, global::Android.Runtime.JniHandleOwnership o) : base(p, o)
        {
            // Added default constructor to prevent crash when accessing header/footer row in ListViewAdapter.Dispose
        }

        public ViewGroupContainer(Context context) : base(context)
        {
        }

        public IVisualElementRenderer Child
        {
            set
            {
                if (_child != null)
                    RemoveView(_child.View);

                _child = value;

                if (value != null)
                    AddView(value.View);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (_child == null)
                return;

            _child.UpdateLayout();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            if (_child == null)
            {
                SetMeasuredDimension(0, 0);
                return;
            }

            VisualElement element = _child.Element;

            Context ctx = Context;

            var width = (int)ctx.FromPixels(MeasureSpecFactory.GetSize(widthMeasureSpec));

            SizeRequest request = _child.Element.Measure(width, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            Microsoft.Maui.Controls.Compatibility.Layout.LayoutChildIntoBoundingRegion(_child.Element, new Rect(0, 0, request.Request.Width, request.Request.Height));

            int widthSpec = MeasureSpecFactory.MakeMeasureSpec((int)ctx.ToPixels(request.Request.Width), MeasureSpecMode.Exactly);
            int heightSpec = MeasureSpecFactory.MakeMeasureSpec((int)ctx.ToPixels(request.Request.Height), MeasureSpecMode.Exactly);

            _child.View.Measure(widthMeasureSpec, heightMeasureSpec);

            SetMeasuredDimension(widthSpec, heightSpec);
        }
    }


}