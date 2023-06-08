using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("IndustryIdentifier")]
	public class IndustryIdentifier
	{
		public string Type { get; set; }
		public string Identifier { get; set; }
	}
}
