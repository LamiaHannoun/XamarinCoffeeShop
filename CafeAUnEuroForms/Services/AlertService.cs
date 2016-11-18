using System;
using System.Threading.Tasks;
using CafeAUnEuro;

namespace CafeAUnEuroForms
{
	public class AlertService : IAlertService
	{
		public Task<bool> ShowAlertAsync(string msg, string title, string yes, string no)
		{
			var page = App.Current.MainPage;
			return page.DisplayAlert(title, msg, yes, no);
		}

	}
}
