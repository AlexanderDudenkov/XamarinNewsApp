using System;

using Android.Content;

using Android.Widget;
using NewsApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NewsApp.view.custom;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(UnderlineLabelRenderer))]
namespace NewsApp.Droid
{
    public class UnderlineLabelRenderer : LabelRenderer
    {
        public UnderlineLabelRenderer(Context context) : base(context)
        { }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var textView = (TextView)Control;
                textView.PaintFlags = PaintFlags.UnderlineText;
            }
        }
    }
}