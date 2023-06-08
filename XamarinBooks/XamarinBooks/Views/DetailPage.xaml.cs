using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBooks.Models;
using XamarinBooks.ViewModels;

namespace XamarinBooks.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		private DetailViewModel viewModel;
		public DetailPage (BookItem itemSelected)
		{
			InitializeComponent ();

			viewModel = new DetailViewModel(itemSelected);

			BindingContext = viewModel;

		}
	}
}