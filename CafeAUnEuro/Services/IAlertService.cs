using System;
using System.Threading.Tasks;

namespace CafeAUnEuro
{
	public interface IAlertService
	{
		Task<bool> ShowAlertAsync(
			string msg,
			string title,
			string yes,
			string no);
	}
}
