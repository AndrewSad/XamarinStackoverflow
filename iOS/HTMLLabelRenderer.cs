using System.ComponentModel;
using Foundation;
using stackoverflown;
using stackoverflown.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HTMLLabel), typeof(HTMLLabelRenderer))]
namespace stackoverflown.iOS
{
	public class HTMLLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
			{
				var attr = new NSAttributedStringDocumentAttributes();
				var nsError = new NSError();
				attr.DocumentType = NSDocumentType.HTML;

				var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
				Control.Lines = 2;
				Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
				{
					var attr = new NSAttributedStringDocumentAttributes();
					var nsError = new NSError();
					attr.DocumentType = NSDocumentType.HTML;

					var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
					Control.Lines = 2;
					Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
				}
			}
		}
	}
}