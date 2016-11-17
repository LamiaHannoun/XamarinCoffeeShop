using System;
using System.Threading.Tasks;
using UIKit;

namespace CafeAUnEuro.iOS
{
	public class AlertService : IAlertService
	{
		internal void SetCurrentViewController(CoffeeTableViewController coffeeTableViewController)
		{
			controller = coffeeTableViewController;
		}

		private UIViewController controller;

		public Task<bool> ShowAlertAsync(string msg, string title, string yes, string no)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();

			var alert = UIAlertController.Create(
				title, msg, UIAlertControllerStyle.ActionSheet);

			alert.AddAction(UIAlertAction.Create(
			  "Yes", UIAlertActionStyle.Default,
			  a => taskCompletionSource.SetResult(true)));

			alert.AddAction(UIAlertAction.Create(
			  "No", UIAlertActionStyle.Default,
			  a => taskCompletionSource.SetResult(false)));


			controller.PresentViewController(alert, true, null);
			return taskCompletionSource.Task;
		}

	}
}
