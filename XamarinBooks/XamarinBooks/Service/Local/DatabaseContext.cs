using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinBooks.Models;

namespace XamarinBooks.Service.Local
{

	public class DatabaseContext : SQLiteConnection
	{ 

		public DatabaseContext(string databasePath) : base(databasePath)
		{
			CreateTable<VolumeInfoDb>();
		}

		public TableQuery<VolumeInfoDb> book => Table<VolumeInfoDb>();

		public int SalveBookData(VolumeInfoDb book)
		{
			bool isBookAlreadSaved = VerifyBook(book);

			if (!isBookAlreadSaved)
			{
				return Insert(book);
			}
			else
			{
				return -1;
			}
		}

		private bool VerifyBook(VolumeInfoDb book)
		{
			string query = "SELECT * FROM VolumeInfoDb Where Id = " + book.Id;
			int result = ExecuteScalar<int>(query);

			if (result == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public VolumeInfoDb ConvertObject(BookItem book)
		{
			VolumeInfoDb newObject = new VolumeInfoDb()
			{
				Title = book.VolumeInfo.Title,
				Authors = book.VolumeInfo.Authors.FirstOrDefault(),
				Publisher = book.VolumeInfo.Publisher,
				PublishedDate = book.VolumeInfo.PublishedDate,
				Description = book.VolumeInfo.Description,
				PageCount = book.VolumeInfo.PageCount,
				PrintType = book.VolumeInfo.PrintType,
				Categories = book.VolumeInfo.Categories?.FirstOrDefault(),
				AverageRating = book.VolumeInfo.AverageRating,
				RatingsCount = book.VolumeInfo.RatingsCount,
				MaturityRating = book.VolumeInfo.MaturityRating,
				AllowAnonLogging = book.VolumeInfo.AllowAnonLogging,
				ContentVersion = book.VolumeInfo.ContentVersion,
				ImageLink = book.VolumeInfo.ImageLinks.Thumbnail,
				Language = book.VolumeInfo.Language,
				PreviewLink = book.VolumeInfo.PreviewLink,
				InfoLink = book.VolumeInfo.InfoLink,
				CanonicalVolumeLink = book.VolumeInfo.CanonicalVolumeLink
			};

			return newObject;
		}

		public List<VolumeInfoDb> GetFavoriteBooks()
		{
			return book.ToList();
		}
	}
}
