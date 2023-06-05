using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using XamarinBooks.Dependency;

namespace XamarinBooks
{
	public partial class MainPage : ContentPage
	{
		Xamarin.Auth.Presenters.OAuthLoginPresenter presenter;

		public MainPage()
		{
			presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();

			InitializeComponent();
		}

		private void OnGoogleLoginClicked(object sender, EventArgs e)
		{

			var gmailAuthenticator = DependencyService.Get<IGmailAuthenticator>();
			gmailAuthenticator.Authenticate();
		}

	}
}
