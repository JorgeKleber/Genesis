using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XamarinBooks.Models;

namespace XamarinBooks.Converters
{
	public class ImageDetailConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string image = (string)value;

			if (string.IsNullOrEmpty(image))
			{
				return "default_image.png";
			}

			return image;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
