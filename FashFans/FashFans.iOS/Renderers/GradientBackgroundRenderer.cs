using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using FashFans.Controls;
using FashFans.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientBackground), typeof(GradientBackgroundRenderer))]
namespace FashFans.iOS.Renderers {
    public class GradientBackgroundRenderer : VisualElementRenderer<StackLayout> {

        public override void Draw(CGRect rect) {
            base.Draw(rect);

            GradientBackground gradientBackground = (GradientBackground)Element;

            CGColor startColor = gradientBackground.StartColor.ToCGColor();
            CGColor middleColor = gradientBackground.MiddleColor.ToCGColor();
            CGColor endColor = gradientBackground.EndColor.ToCGColor();

            var gradientLayer = new CAGradientLayer {
                StartPoint = new CGPoint(0.5, 0),
                EndPoint = new CGPoint(0.5, 1)
            };

            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] {
                startColor,
                middleColor,
                endColor
            };

            NativeView.Layer.InsertSublayer(gradientLayer, 1);
        }
    }
}