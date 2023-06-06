using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.OS;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Content;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinBooks.Views;

namespace XamarinBooks.Droid
{
    [Activity(Label = "XamarinBooks", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		private static int RC_SIGN_IN = 9001;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);

			LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (requestCode == RC_SIGN_IN)
			{
				var task = GoogleSignIn.GetSignedInAccountFromIntent(data).Result;

				App.Current.MainPage = new NavigationPage(new WelcomePage());
				//HandleSignInResult(task);
			}
		}

		private void HandleSignInResult(GoogleSignInAccount completedTask)
		{
			try
			{
				GoogleSignInAccount account =  completedTask;

				string accessToken = account.IdToken;
			}
			catch (ApiException ex)
			{
				
			}
		}

	}
}