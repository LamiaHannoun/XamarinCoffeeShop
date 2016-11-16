using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAUnEuro
{
	public interface ICoffeeService
	{
		Task<List<string>> GetCoffeesDataAsync();
		Task<IList<Record>> GetCoffeesAsync();
	}
}
