using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinBooks.Models;

namespace XamarinBooks.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		private const string _LIKED_ICON = "heartOutline";
		private BookItem _ItemSelected;
		private string _Title;
		private string _Autor;
		private string _Status;
		private string _BuyLink;
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

		public string Autor
		{
			get => _Autor;
			set
			{
				_Autor = value;
				Notify("Autor");
			}
		}
		public string Status
		{
			get => _Status;
			set
			{
				_Status = value;
				Notify("Status");
			}
		}
		public string BuyLink
		{
			get => _BuyLink;
			set
			{
				_BuyLink = value;
				Notify("BuyLink");
			}
		}

		public ICommand FavoriteBookCommand { get; set; }
		public ICommand OpenInBrowserCommand { get; set; }


		public DetailViewModel(BookItem itemSelected)
		{
			AppClass = App.Current as App;
			ItemSelected = itemSelected;

			Title = itemSelected.VolumeInfo.Title;
			ImageBook = itemSelected.VolumeInfo.ImageLinks?.Thumbnail;
			AboutBook = itemSelected.VolumeInfo.Description;
			Autor = itemSelected.VolumeInfo.Authors.First();
			BuyLink = itemSelected.VolumeInfo.InfoLink;

			FavoriteBookCommand = new Command(FavoriteBookEvent);
			OpenInBrowserCommand = new Command(OpenInBrowserEvent);
		}

		private async void OpenInBrowserEvent(object obj)
		{
			await Launcher.OpenAsync(new Uri(ItemSelected.AccessInfo.WebReaderLink));
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
