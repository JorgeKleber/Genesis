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
using XamarinBooks.ViewModels;

namespace XamarinBooks.Views
{
	public partial class MainPage : ContentPage
	{
		private MainViewModel viewModel;

		public MainPage()
		{
			InitializeComponent();

			viewModel= new MainViewModel();

			BindingContext= viewModel;
		}
    }
}