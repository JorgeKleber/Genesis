using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using XamarinBooks.Models;

namespace XamarinBooks.Converters
{
	public class EmptyStringToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			ImageLinks item = (ImageLinks)value;

			if (item == null)
			{
				return "default_image.png";
			}

			return item.Thumbnail;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
