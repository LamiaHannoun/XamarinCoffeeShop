using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CafeAUnEuroForms
{
	public partial class CoffeeMapPage : ContentPage
	{
		string coffeeName;
		double latitude;
		double longitude;
		string coffeeAddress;

		public CoffeeMapPage()
		{
			InitializeComponent();
		}

		public CoffeeMapPage(
			double latitude,
			double longitude,
			string coffeeName,
			string coffeeAddress)
		{
			InitializeComponent();

			this.latitude = latitude;
			this.longitude = longitude;
			this.coffeeName = coffeeName;
			this.coffeeAddress = coffeeAddress;

			var position = new Position(latitude, longitude);
			var distance = Distance.FromMiles(0.05);
			var pin = new Pin
			{
				Label = coffeeName,
				Position = position,
				Address = coffeeAddress
			};
			
			MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position,distance));
			MyMap.Pins.Add(pin);
		}
	}
}
