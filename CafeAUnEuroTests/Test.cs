using NUnit.Framework;
using System;
using CafeAUnEuro;
using NSubstitute;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace CafeAUnEuroTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void ViewModelShouldLoadCoffeesWhenClickingOnLoadCommandAndSayingYes()
		{
			var alertServiceStub = Substitute.For<IAlertService>();
			alertServiceStub
					 .ShowAlertAsync(Arg.Any<string>(),
									 Arg.Any<string>(),
									 Arg.Any<string>(),
									 Arg.Any<string>())
					 .Returns(Task.FromResult(true));
			SimpleIoc.Default.Register<IAlertService>(() => alertServiceStub);

			var alertService = SimpleIoc.Default.GetInstance<IAlertService>();
			var serviceSub = Substitute.For<ICoffeeService>();

			var viewModel = new CoffeeListViewModel(serviceSub,alertService);
			viewModel.LoadCoffeesCommand.Execute(null);

			serviceSub.Received().GetCoffeesDataAsync();
		}

		[Test]
		public void ShoudNavigateToListFromHomePage()
		{
			var viewModel = new HomePageViewModel();
			var stub = Substitute.For<IHomeView>();
			viewModel.Init(stub);
			viewModel.GoToListCommand.Execute(null);
			stub.Received(1).GoToList();
		}

	}
}
