using Refit;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBooks.CustomRenderers;
using XamarinBooks.Service;
using XamarinBooks.Views;

namespace XamarinBooks
{
	public partial class App : Application
	{
		public static IBooksApi GoogleBooksApi { get; private set; }

		public App()
		{
			InitializeComponent();

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://www.googleapis.com/books/v1")
			};

			GoogleBooksApi = RestService.For<IBooksApi>(httpClient);

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
