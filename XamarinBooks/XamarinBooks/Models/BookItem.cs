using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("BookItem")]
	public class BookItem
	{
		[PrimaryKey]
		public string Id { get; set; }
		public string Kind { get; set; }
		public string Etag { get; set; }
		public string SelfLink { get; set; }
		public VolumeInfo VolumeInfo { get; set; }
		public SaleInfo SaleInfo { get; set; }
		public AccessInfo AccessInfo { get; set; }
		public SearchInfo SearchInfo { get; set; }
	}


}
