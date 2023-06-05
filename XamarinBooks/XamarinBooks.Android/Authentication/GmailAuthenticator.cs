using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Xamarin.Forms;
using MyApp.Droid;
using XamarinBooks.Dependency;

[assembly: Dependency(typeof(GmailAuthenticator))]
namespace MyApp.Droid
{
	public class GmailAuthenticator : Java.Lang.Object, IGmailAuthenticator
	{
		private static int RC_SIGN_IN = 9001;
		private GoogleSignInClient googleSignInClient;

		public void Authenticate()
		{
			var activity = Xamarin.Essentials.Platform.CurrentActivity;

			GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
				.RequestIdToken("577336758861-5fjtcsgrhmfm8ihgiqn9nc2o0qs9jm3b.apps.googleusercontent.com") // Substitua pelo seu Web Client ID
				.RequestEmail()
				.Build();

			googleSignInClient = GoogleSignIn.GetClient(activity, gso);

			Intent signInIntent = googleSignInClient.SignInIntent;
			activity.StartActivityForResult(signInIntent, RC_SIGN_IN);
		}
	}
}
