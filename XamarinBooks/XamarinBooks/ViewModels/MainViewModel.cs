using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;
using XamarinBooks.Converters;
using XamarinBooks.Dependency;
using XamarinBooks.Service;
using XamarinBooks.Views;

namespace XamarinBooks.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private OAuthLoginPresenter presenter;

		private int indice = 0;
		private bool canLoad = false;

		private string _SearchText;
		private BookItem _ItemSelecionado;
		private ObservableCollection<BookItem> _SearchResultList;
		private ICommand _GetMoreItensCommand;

		public ICommand GoogleSignInCommand { get; set; }
		public ICommand SearchCommand { get; set; }
		public ICommand ItemTappedCommand { get; set; }
		public ICommand ScrolledCommand { get; set; }
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
			set
			{
				_SearchResultList = value;
				Notify("SearchResultList");
			}
		}

		public BookItem ItemSelecionado
		{
			get => _ItemSelecionado;
			set
			{
				_ItemSelecionado = value;
				Notify("ItemSelecionado");
			}
		}

		public ICommand GetMoreItensCommand
		{
			get => _GetMoreItensCommand;
			set
			{
				_GetMoreItensCommand = value;
				Notify("GetMoreItensCommand");
			}
		}

		public MainViewModel()
		{
			presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();

			GoogleSignInCommand = new Command(LoginClickEvent);
			SearchCommand = new Command(SearchClickEvent);
			ItemTappedCommand = new Command(ItemTappedEvent);
			//ScrolledCommand = new Command(ScrollListEvent);

			SearchText = "harry";
		}

		private void ScrollListEvent(object obj)
		{

		}

		private async void LoadMoreItensEvent(object obj)
		{
			if (indice == 0)
			{
				indice++;

				return;
			}

			try
			{
				var result = await App.GoogleBooksApi.GetBookVolume(SearchText, indice);

				foreach (BookItem item in result.Items)
				{
					SearchResultList.Add(item);
				}

				indice++;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro: {ex.Message}");
			}
		}

		private async void ItemTappedEvent(object obj)
		{
			Debug.WriteLine("ITEM SELECIONADO: " + ItemSelecionado);

			await App.Current.MainPage.Navigation.PushModalAsync(new DetailPage(ItemSelecionado), true);
		}

		private async void SearchClickEvent(object obj)
		{
			//indice = 0;
			//canLoad = false;

			//LoadList();

			try
			{
				var result = await App.GoogleBooksApi.GetBookVolume(SearchText, indice);

				if (indice == 0)
				{
					SearchResultList = new ObservableCollection<BookItem>(result.Items);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro: {ex.Message}");
			}

			GetMoreItensCommand = new Command(LoadMoreItensEvent);
		}

		private void LoginClickEvent(object obj)
		{
			var gmailAuthenticator = DependencyService.Get<IGmailAuthenticator>();
			gmailAuthenticator.Authenticate();
		}
	}
}
