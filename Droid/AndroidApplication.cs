using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;

namespace CafeAUnEuro.Droid
{
	[Application]
	public class AndroidApplication : Application,Application.IActivityLifecycleCallbacks
	{
		public AndroidApplication(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership) 
		{ }

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).SetCurrentActivity(activity);

		}

		public void OnActivityDestroyed(Activity activity)
		{
			
		}

		public void OnActivityPaused(Activity activity)
		{
			
		}

		public void OnActivityResumed(Activity activity)
		{
			((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).SetCurrentActivity(activity);

		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
			
		}

		public void OnActivityStarted(Activity activity)
		{
			((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).SetCurrentActivity(activity);

		}

		public void OnActivityStopped(Activity activity)
		{
			
		}

		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);

			SimpleIoc.Default.Register<ICoffeeService,CoffeeService>();
			SimpleIoc.Default.Register<IAlertService,AlertService>();
			SimpleIoc.Default.Register<HomePageViewModel>();
			SimpleIoc.Default.Register<CoffeeListViewModel>();
		}

		public override void OnTerminate()
		{
			base.OnTerminate();
			UnregisterComponentCallbacks(this);
		}
	}
}
