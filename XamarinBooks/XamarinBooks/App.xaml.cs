using Refit;
using System;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using XamarinBooks.Service.Local;
using XamarinBooks.Service.Remote;
using XamarinBooks.Views;

namespace XamarinBooks
{
	public partial class App : Application
	{
		public Action ReloadFavoriteList;
		public static IBooksApi GoogleBooksApi { get; private set; }

		string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinBooksDb.db3");
		public DatabaseContext database { get; set; }

		public App()
		{
			database = new DatabaseContext(dbPath);

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://www.googleapis.com/books/v1")
			};

			GoogleBooksApi = RestService.For<IBooksApi>(httpClient);

			InitializeComponent();

			MainPage =  new HomePage();
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
