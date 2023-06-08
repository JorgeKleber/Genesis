using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("SaleInfo")]
	public class SaleInfo
	{
		public string Country { get; set; }
		public string Saleability { get; set; }
		public bool IsEbook { get; set; }
	}
}
