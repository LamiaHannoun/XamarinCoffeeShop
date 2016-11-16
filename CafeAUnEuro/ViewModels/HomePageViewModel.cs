using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CafeAUnEuro
{
	public interface IHomeView
	{
		void GoToList();
	}

	public class HomePageViewModel:ViewModelBase
	{
		public IHomeView HomeView { get; set; }
		public RelayCommand GoToListCommand;

		public HomePageViewModel()
		{
			GoToListCommand = new RelayCommand(GoToList);
		}

		public void Init(IHomeView homeView) {
			HomeView = homeView;
		}

		public override void Cleanup()
		{
			HomeView = null;
			base.Cleanup();
		}

		private void GoToList() {
			HomeView?.GoToList();
		}
	}
}
