using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBooks.Models
{
	[Table("PanelizationSummary")]
	public class PanelizationSummary
	{
		public bool ContainsEpubBubbles { get; set; }
		public bool ContainsImageBubbles { get; set; }
	}
}
