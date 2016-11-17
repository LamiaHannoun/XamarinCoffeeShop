using Foundation;
using System;
using UIKit;
using GalaSoft.MvvmLight.Ioc;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics;

namespace CafeAUnEuro.iOS
{
    public partial class CoffeeTableViewController : UITableViewController
    {
		private CoffeeListViewModel _viewModel;

		public CoffeeTableViewController(IntPtr handle) : base(handle)
		{
			
		}

		void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(_viewModel.Coffees):
					TableView.Source = new CoffeeTableSource(this, _viewModel.Coffees);
					break;
				default:
					break;
			}
		}
		private Record _selectedItem;
		internal void OnRecordSelected(Record record)
		{
			_selectedItem = record;
			PerformSegue("ShowMap", this);

			//var currentLong = record.geometry.coordinates[0];
			//var currentLat = record.geometry.coordinates[1];
		 	//var scurrentLong = currentLong.ToString(CultureInfo.InvariantCulture);
			//var scurrentLat = currentLat.ToString(CultureInfo.InvariantCulture);
			//var url = $"http://maps.apple.com/?ll={currentLat},{currentLong}&sll={scurrentLat},{scurrentLong}";
			//UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
	
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			switch (segue.Identifier)
			{
				case "ShowMap":
					var mapController = segue.DestinationViewController as CoffeeMapViewController;
					if (mapController != null)
					{
						try
						{
							var record = _selectedItem;
							var currentLong = record.geometry.coordinates[0];
							var currentLat = record.geometry.coordinates[1];

							mapController.Latitude = currentLat;
							mapController.Longitude = currentLong;
							mapController.PinTitle = record.fields.nom_du_cafe;
							mapController.PinSubtitle = record.fields.adresse;
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.StackTrace);

						}
					}
					break;
				default:
					break;

			}
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
	
			_viewModel = SimpleIoc.Default.GetInstance<CoffeeListViewModel>();
			((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).SetCurrentViewController(this);

			_viewModel.PropertyChanged += OnViewModelPropertyChanged;
			_viewModel.LoadCoffeesCommand.Execute(null);
		}

		public override void ViewWillDisappear(bool animated)
		{
			_viewModel?.Cleanup(); 
			TableView.Source = null;

			base.ViewWillDisappear(animated);

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				TableView.Source = null;
				_viewModel?.Cleanup();
				if (_viewModel != null)
				{
					_viewModel.PropertyChanged -= OnViewModelPropertyChanged;
				}
				TableView = null;
				_viewModel = null;
			}
			base.Dispose(disposing);
		}
    }
}