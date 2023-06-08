using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("SearchInfo")]
	public class SearchInfo
	{
		public string TextSnippet { get; set; }
	}
}
