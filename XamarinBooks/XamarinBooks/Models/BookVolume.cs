using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("BookVolume")]
	public class BookVolume
	{
		public string Kind { get; set; }
		public int TotalItems { get; set; }
		public List<BookItem> Items { get; set; }
	}
}
