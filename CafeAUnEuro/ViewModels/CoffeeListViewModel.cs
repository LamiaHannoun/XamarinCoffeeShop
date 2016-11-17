using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace CafeAUnEuro
{
	public class CoffeeListViewModel: ViewModelBase
	{
		private ICoffeeService CoffeeService;

		private readonly IAlertService alertService;

		private IList<Record> coffees;
		public IList<Record> Coffees 
		{
			get { return coffees;}
			set
			{
				Set(ref coffees, value);
			}
		}

		private bool isLoading;
		public bool IsLoading {
			get { return isLoading; }
			set
			{
				Set(ref isLoading, value);
			} }
		public RelayCommand LoadCoffeesCommand { get; set; }

		public CoffeeListViewModel(ICoffeeService coffeeService,IAlertService alertService)
		{
			this.CoffeeService = coffeeService;
			this.alertService = alertService;
			LoadCoffeesCommand = new RelayCommand(() => InitializeData());
		}

		public async void InitializeData()
		{
			try
			{
				IsLoading = true;
				var alertResult = await alertService.ShowAlertAsync(
					"Would you like to display coffees list",
					"Confirmation",
					"Yes",
					"No");
				if (alertResult)
				{
					Coffees= await CoffeeService.GetCoffeesAsync();
				}
			}
			finally { IsLoading = false; }
		}

		public override void Cleanup()
		{
			coffees = null;
			base.Cleanup();
		}

	}
}
