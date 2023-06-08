using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("ReadingModes")]
	public class ReadingModes
	{
		public bool Text { get; set; }
		public bool Image { get; set; }
	}
}
