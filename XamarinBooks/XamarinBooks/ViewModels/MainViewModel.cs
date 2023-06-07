using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBooks.Dependency;
using XamarinBooks.Service;
using XamarinBooks.Views;

namespace XamarinBooks.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		Xamarin.Auth.Presenters.OAuthLoginPresenter presenter;

		private string _SearchText;
		private BookItem _ItemSelecionado;
		private ObservableCollection<BookItem> _SearchResultList;

		public ICommand GoogleSignInCommand { get; set; }
		public ICommand SearchCommand { get; set; }
		public ICommand ItemTappedCommand { get; set; }
		public string SearchText
		{
			get => _SearchText;
			set
			{
				_SearchText = value;
				Notify("SearchText");
			}
		}

		public ObservableCollection<BookItem> SearchResultList
		{
			get => _SearchResultList;
			set {
				_SearchResultList = value;
				Notify("SearchResultList");
			}
		}
		
		public BookItem ItemSelecionado
		{
			get => _ItemSelecionado;
			set {
				_ItemSelecionado = value;
				Notify("ItemSelecionado");
			}
		}

		public MainViewModel()
		{
			presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();

			GoogleSignInCommand = new Command(LoginClickEvent);
			SearchCommand = new Command(SearchClickEvent);
			ItemTappedCommand = new Command(ItemTappedEvent);

			SearchText = "harry";
		}

		private async void ItemTappedEvent(object obj)
		{
			Debug.WriteLine("ITEM SELECIONADO: " + ItemSelecionado);

			await App.Current.MainPage.Navigation.PushModalAsync(new DetailPage());
		}

		private async void SearchClickEvent(object obj)
		{
			try
			{
				var result = await App.GoogleBooksApi.GetBookVolume(SearchText);

				SearchResultList = new ObservableCollection<BookItem>(result.Items);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro: {ex.Message}");
			}
		}

		private void LoginClickEvent(object obj)
		{
			var gmailAuthenticator = DependencyService.Get<IGmailAuthenticator>();
			gmailAuthenticator.Authenticate();
		}
	}
}
