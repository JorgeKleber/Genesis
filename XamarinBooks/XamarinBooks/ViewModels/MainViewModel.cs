using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBooks.Dependency;
using XamarinBooks.Service;

namespace XamarinBooks.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		Xamarin.Auth.Presenters.OAuthLoginPresenter presenter;

		private string _SearchText;

		public ICommand GoogleSignInCommand { get; set; }
		public ICommand SearchCommand { get; set; }
		public string SearchText
		{
			get => _SearchText;
			set
			{
				_SearchText = value;
				Notify("SearchText");
			}
		}

		public MainViewModel()
		{
			presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();

			GoogleSignInCommand = new Command(LoginClickEvent);
			SearchCommand = new Command(SearchClickEvent);
		}


		private async void SearchClickEvent(object obj)
		{
			try
			{
				var result = await App.GoogleBooksApi.GetBookVolume(SearchText);

				var firstBookTitle = result.Items;

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
