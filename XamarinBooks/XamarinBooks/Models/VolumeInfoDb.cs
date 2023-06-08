using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("VolumeInfoDb")]
	public class VolumeInfoDb
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Authors { get; set; }
		public string Publisher { get; set; }
		public string PublishedDate { get; set; }
		public string Description { get; set; }
		public int PageCount { get; set; }
		public string PrintType { get; set; }
		public string Categories { get; set; }
		public double AverageRating { get; set; }
		public int RatingsCount { get; set; }
		public string MaturityRating { get; set; }
		public bool AllowAnonLogging { get; set; }
		public string ContentVersion { get; set; }
		public string ImageLink { get; set; }
		public string Language { get; set; }
		public string PreviewLink { get; set; }
		public string InfoLink { get; set; }
		public string CanonicalVolumeLink { get; set; }
	}
}
