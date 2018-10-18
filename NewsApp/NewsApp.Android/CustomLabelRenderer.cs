using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NewsApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NewsApp.view.custom;


[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace NewsApp.Droid
{
    public class CustomLabelRenderer : ViewRenderer<CustomLabel, TextView>
    {
        public CustomLabelRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomLabel> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                TextView textView = new TextView(Context);
                textView.SetTextColor(Android.Graphics.Color.DarkGreen);
                textView.Text = "Android";

                SetNativeControl(textView);
            }
        }
    }
}