using System;
using System.Collections.Generic;
using System.Text;
using XamarinBooks.Service;

namespace XamarinBooks.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		private BookItem _ItemSelected;
		private string _Title;
		private string _AboutBook;
		private string _ImageBook;

		public BookItem ItemSelected
		{
			get => _ItemSelected;
			set
			{
				_ItemSelected = value;
				Notify("ItemSelected");
			}
		}

		public string Title
		{
			get => _Title;
			set
			{
				_Title = value;
				Notify("Title");
			}
		}
		
		public string AboutBook
		{
			get => _AboutBook;
			set
			{
				_AboutBook = value;
				Notify("AboutBook");
			}
		}

		public string ImageBook
		{
			get => _ImageBook;
			set
			{
				_ImageBook = value;
				Notify("ImageBook");
			}
		}

		public DetailViewModel(BookItem itemSelected)
		{
			ItemSelected = itemSelected;

			Title = itemSelected.VolumeInfo.Title;
			ImageBook = itemSelected.VolumeInfo.ImageLinks.Thumbnail;
			AboutBook = itemSelected.VolumeInfo.Description;
		}
	}
}
