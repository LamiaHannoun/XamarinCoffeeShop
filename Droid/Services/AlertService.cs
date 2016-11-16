using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;

namespace CafeAUnEuro.Droid
{
	public class AlertService : IAlertService
	{
		private Activity _context;

		public Task<bool> ShowAlertAsync(string msg, string title, string yes, string no)
		{
			var tcs = new TaskCompletionSource<bool>();
			Handler handler = new Handler();
			handler.Post(() =>
			{
				var dialog = new AlertDialog.Builder(_context)
				                            .SetTitle(title)
				                            .SetMessage(msg)
				                            .SetPositiveButton("Yes", (sender, args) =>
											{
												tcs.SetResult(true);
											})
				                            .SetNegativeButton("No", (sender, args) =>
					 						{
						 						tcs.SetResult(false);
											}).Create();

				dialog.Show();
				handler?.Dispose();
			});
			return tcs.Task;
		}

		internal void SetCurrentActivity(Activity activity)
		{
			_context = activity;
		}
	}
}
