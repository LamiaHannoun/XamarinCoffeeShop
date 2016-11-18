using System;
using System.Collections.Generic;
using System.Linq;
using CafeAUnEuro;
using Foundation;
using GalaSoft.MvvmLight.Ioc;
using UIKit;

namespace CafeAUnEuroForms.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			Xamarin.FormsMaps.Init();

			LoadApplication(new App());
			SimpleIoc.Default.Register<ICoffeeService, CoffeeService>();
			SimpleIoc.Default.Register<IAlertService, AlertService>();
			SimpleIoc.Default.Register<HomePageViewModel>();
			SimpleIoc.Default.Register<CoffeeListViewModel>();


			return base.FinishedLaunching(app, options);
		}
	}
}
