using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace stackoverflown
{
	public class DateTimeValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is long)
			{
				
				var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

				Debug.WriteLine("{0:g}",epoch.AddSeconds((long)value));

				return epoch.AddSeconds((long)value).ToString("g");
			}
			else
			{
				return value;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
