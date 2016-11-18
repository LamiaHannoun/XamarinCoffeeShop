
using System;
using System.Collections.Generic;
using System.Globalization;
using CafeAUnEuro;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace CafeAUnEuroForms
{
	public partial class CoffeListPage : ContentPage
	{
		private CoffeeListViewModel viewModel;

		public CoffeListPage()
		{
			InitializeComponent();
			viewModel = SimpleIoc.Default.GetInstance<CoffeeListViewModel>();
			BindingContext = viewModel;

		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var record = e.SelectedItem as Record;
			if (record == null)
				return;
			var longitude = record.geometry.coordinates[0];
			var latitude = record.geometry.coordinates[1];
			var coffeeName = record.fields.nom_du_cafe;
			var coffeeAddress = record.fields.adresse;

			await Navigation.PushAsync(new CoffeeMapPage(latitude,longitude,coffeeName,coffeeAddress),true);
		}

		protected override void OnAppearing()
		{
			viewModel.LoadCoffeesCommand.Execute(null);
		}
	}
}
