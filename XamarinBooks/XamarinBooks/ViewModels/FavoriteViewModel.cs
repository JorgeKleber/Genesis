using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using XamarinBooks.Models;

namespace XamarinBooks.ViewModels
{
	public class FavoriteViewModel : ViewModelBase
	{
		private ObservableCollection<VolumeInfoDb> _FavoriteList;

		public FavoriteViewModel(ObservableCollection<VolumeInfoDb> favoriteList)
		{
			FavoriteList = favoriteList;
		}

		public ObservableCollection<VolumeInfoDb> FavoriteList
		{
			get => _FavoriteList;
			set
			{
				_FavoriteList = value;
				Notify("FavoriteList");
			}
		}
	}
}
