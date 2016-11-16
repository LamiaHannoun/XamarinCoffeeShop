
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CafeAUnEuro.Droid
{
	[Activity(Label = "@string/coffeeMap")]
	public class CoffeeMapActivity : Activity,IOnMapReadyCallback
	{
		private MapFragment _mapFragment;
		private double latitude;
		private double longitude;
		private string coffeeName;

		public void OnMapReady(GoogleMap googleMap)
		{
			googleMap.MapType = GoogleMap.MapTypeHybrid;
			LatLng location = new LatLng(latitude,longitude);

			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(location);
			builder.Zoom(18);

			CameraPosition cameraPosition = builder.Build();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

			googleMap.MoveCamera(cameraUpdate);

			MarkerOptions markerOpt1 = new MarkerOptions();
			markerOpt1.SetPosition(location);
			markerOpt1.SetTitle(coffeeName);
			googleMap.AddMarker(markerOpt1);

		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CoffeeMap);

			latitude = double.Parse(Intent.GetStringExtra("lat"));
			longitude= double.Parse(Intent.GetStringExtra("long"));
			coffeeName= Intent.GetStringExtra("name");
		
			_mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
			_mapFragment.GetMapAsync(this);
		}
	}
}
