using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using System;
using GalaSoft.MvvmLight.Ioc;

namespace CafeAUnEuro.Droid
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity,IHomeView
	{
		private Button loadCoffeesBtn;
		private HomePageViewModel viewModel;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			viewModel = SimpleIoc.Default.GetInstance<HomePageViewModel>();
			viewModel.Init(this);

			SetContentView(Resource.Layout.Main);

		    loadCoffeesBtn = FindViewById<Button>(Resource.Id.myButton);
			loadCoffeesBtn.Click += onClickButton;
		}

		private void onClickButton(object sender,EventArgs e)
		{
			viewModel?.GoToListCommand.Execute(null);

		}

		public void GoToList()
		{
			Intent intent = new Intent(this, typeof(CoffeeListActivity));
			StartActivity(intent);
		}

		protected override void OnDestroy()
		{
			if (loadCoffeesBtn != null)
			{
				loadCoffeesBtn.Click -= onClickButton;
			}
			viewModel?.Cleanup();

			base.OnDestroy();
		}

	}
}

