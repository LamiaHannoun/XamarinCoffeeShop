using Foundation;
using System;
using UIKit;
using MapKit;
using CoreLocation;

namespace CafeAUnEuro.iOS
{
    public partial class CoffeeMapViewController : UIViewController
    {
		public double Latitude { get; internal set; }

		public double Longitude { get; internal set; }

		public string PinTitle { get; internal set; }

		public string PinSubtitle { get; internal set; }


		public CoffeeMapViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		
			var coords = new CLLocationCoordinate2D(this.Latitude, this.Longitude);

			MKCoordinateSpan span = new MKCoordinateSpan(0.05,0.05);//new MKCoordinateSpan(MilesToLatitudeDegrees(2), MilesToLongitudeDegrees(2, coords.Latitude));
			var region = new MKCoordinateRegion(coords, span);
			MapView.SetRegion(region, true);

			var annotation = new BasicMapAnnotation(coords, PinTitle, PinSubtitle);
			this.MapView.AddAnnotation(annotation);

		} 

		//public double MilesToLatitudeDegrees(double miles)
		//{
		//	double earthRadius = 3960.0; // in miles
		//	double radiansToDegrees = 180.0 / Math.PI;
		//	return (miles / earthRadius) * radiansToDegrees;
		//}

		//public double MilesToLongitudeDegrees(double miles, double atLatitude)
		//{
		//	double earthRadius = 3960.0; // in miles
		//	double degreesToRadians = Math.PI / 180.0;
		//	double radiansToDegrees = 180.0 / Math.PI;
		//	// derive the earth's radius at that point in latitude
		//	double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
		//	return (miles / radiusAtLatitude) * radiansToDegrees;
		//}

		public override void ViewWillDisappear(bool animated)
		{
			MapView = null;
			base.ViewWillDisappear(animated);
		
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				MapView = null;
			}

			base.Dispose(disposing);
		}
    }
}