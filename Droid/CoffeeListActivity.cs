
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CafeAUnEuro.Droid
{
	[Activity(Label = "@string/coffeeList")]
	public class CoffeeListActivity : Activity
	{
		private CoffeeListViewModel viewModel;
		private ListView list;
		private CoffeeListAdapter adapter;
		private ProgressBar progressBar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.CoffeeList);

			viewModel = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<CoffeeListViewModel>();
			viewModel.PropertyChanged += OnViewModelPropertyChanged;

			list = FindViewById<ListView>(Resource.Id.myListView);


		    adapter = new CoffeeListAdapter(viewModel.Coffees);

			list.Adapter = adapter;
			list.ItemClick += OnCoffeeListItemClicked;

			progressBar = FindViewById<ProgressBar>(Resource.Id.loading);

			viewModel.LoadCoffeesCommand.Execute(null);
		}

		void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName) {
				case nameof(viewModel.Coffees):
					adapter?.SetItems(viewModel.Coffees);
					break;
				case nameof(viewModel.IsLoading):
					if (progressBar != null)
					{
						progressBar.Visibility = viewModel.IsLoading ? ViewStates.Visible : ViewStates.Gone;
					}
				break;
				default:
					break;
			}
		}


		private void OnCoffeeListItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			//Get our item from the list adapter
			var item = adapter[e.Position];
			var longitude = item.geometry.coordinates[0].ToString(CultureInfo.InvariantCulture);
			var latitude = item.geometry.coordinates[1].ToString(CultureInfo.InvariantCulture);
			var coffeeName = item.fields.nom_du_cafe;


			var intent = new Intent(this, typeof(CoffeeMapActivity));
			intent.PutExtra("lat", latitude);
			intent.PutExtra("long", longitude);
			intent.PutExtra("name", coffeeName);
			StartActivity(intent);
		}

		protected override void OnDestroy()
		{
			if (list != null)
			{
				list.ItemClick -= OnCoffeeListItemClicked;
			}

			list = null;
			adapter?.Dispose();
			adapter = null;
			progressBar = null;

			viewModel?.Cleanup();
			base.OnDestroy();
		}


	}
}
