using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBooks.Models;

namespace XamarinBooks.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		private const string _LIKED_ICON = "heartOutline";
		private BookItem _ItemSelected;
		private string _Title;
		private string _AboutBook;
		private string _ImageBook;
		private string _ImageIcon;
		private App AppClass;

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

		public string ImageIcon
		{
			get => _ImageIcon;
			set
			{
				_ImageIcon = value;
				Notify("ImageIcon");
			}
		}

		public ICommand FavoriteBookCommand { get; set; }

		public DetailViewModel(BookItem itemSelected)
		{
			AppClass = App.Current as App;
			ItemSelected = itemSelected;

			Title = itemSelected.VolumeInfo.Title;
			ImageBook = itemSelected.VolumeInfo.ImageLinks.Thumbnail;
			AboutBook = itemSelected.VolumeInfo.Description;

			FavoriteBookCommand = new Command(FavoriteBookEvent);
		}

		private void FavoriteBookEvent(object obj)
		{
			var teste = AppClass.database.book.ToList();

			ImageIcon = _LIKED_ICON;

			var newObject = AppClass.database.ConvertObject(ItemSelected);

			AppClass.database.SalveBookData(newObject);
		}
	}
}
