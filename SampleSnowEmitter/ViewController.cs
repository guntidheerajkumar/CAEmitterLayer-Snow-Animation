using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace SampleSnowEmitter
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var snowEmitter = new CAEmitterLayer();
			snowEmitter.Position = new CGPoint(this.View.Bounds.Width / 2.0f + 40f, -10f);
			snowEmitter.Size = new CGSize(this.View.Bounds.Size.Width * 2.0f, 0.0f);
			snowEmitter.Mode = "kCAEmitterLayerOutline";
			snowEmitter.Shape = "kCAEmitterLayerLine";
			var snowFlake = new CAEmitterCell();
			snowFlake.BirthRate = 1.0f;
			snowFlake.LifeTime = 120.0f;
			snowFlake.Velocity = -10;
			snowFlake.VelocityRange = 10;
			snowFlake.AccelerationY = 2;
			snowFlake.EmissionRange = 0.5f * (nfloat)Math.PI;
			snowFlake.SpinRange = 0.25f * (nfloat)Math.PI;
			snowFlake.Contents = UIImage.FromBundle("DazFlake").CGImage;
			snowFlake.Color = UIColor.FromRGBA(0.600F, 0.658f, 0.743f, 1.0f).CGColor;

			snowEmitter.ShadowOpacity = 1.0f;
			snowEmitter.ShadowOffset = new CGSize(0.0f, 1.0f);
			snowEmitter.ShadowRadius = 0.0f;
			snowEmitter.ShadowColor = UIColor.Black.CGColor;


			snowEmitter.Cells = new CAEmitterCell[] { snowFlake };
			this.View.Layer.AddSublayer(snowEmitter);
		}
	}
}
