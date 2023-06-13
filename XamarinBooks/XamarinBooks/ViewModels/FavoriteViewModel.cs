using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBooks.Models;
using XamarinBooks.Views;

namespace XamarinBooks.ViewModels
{
	public class FavoriteViewModel : ViewModelBase
	{
		private ObservableCollection<VolumeInfoDb> _FavoriteList;
		private VolumeInfoDb _ItemSelecionado;
		private App AppClass;

		public ObservableCollection<VolumeInfoDb> FavoriteList
		{
			get => _FavoriteList;
			set
			{
				_FavoriteList = value;
				Notify("FavoriteList");
			}
		}

		public VolumeInfoDb ItemSelecionado
		{
			get => _ItemSelecionado;
			set
			{
				_ItemSelecionado = value;
				Notify("ItemSelecionado");
			}
		}

		public ICommand ItemTappedCommand { get; set; }

		public FavoriteViewModel()
		{
			AppClass = App.Current as App;
			AppClass.ReloadFavoriteList = ReloadList;

			AppClass.ReloadFavoriteList.Invoke();

			ItemTappedCommand = new Command(ItemTappedEvent);
		}

		public void ReloadList()
		{
			FavoriteList = new ObservableCollection<VolumeInfoDb>(AppClass.database.GetFavoriteBooks());
		}

		private async void ItemTappedEvent(object obj)
		{
			BookItem bookItem = new BookItem();
			VolumeInfo info = new VolumeInfo();

			List<string> autors = new List<string>();
			autors.Add(ItemSelecionado.Authors);

			ImageLinks links = new ImageLinks();
			links.Thumbnail = ItemSelecionado.ImageLink;

			info.Title = ItemSelecionado.Title;
			info.InfoLink = ItemSelecionado.InfoLink;
			info.ContentVersion = ItemSelecionado.ContentVersion;
			info.Authors = autors;
			info.Publisher = ItemSelecionado.Publisher;
			info.ImageLinks = links;
			info.Description = ItemSelecionado.Description;

			bookItem.VolumeInfo = info;

			await App.Current.MainPage.Navigation.PushModalAsync(new DetailPage(bookItem), true);
		}
	}
}
