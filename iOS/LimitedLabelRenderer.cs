using System;
using stackoverflown;
using stackoverflown.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LimitedLabel), typeof(LimitedLabelRenderer))]
namespace stackoverflown.iOS
{
	public class LimitedLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				UILabel label = Control;
				label.Lines = 2;
			}
		}
	}
}
