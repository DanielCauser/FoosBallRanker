using Prism.Unity;
using FoosBallRanker.Views;
using Xamarin.Forms;
using FoosBallRanker.ViewModels;

namespace FoosBallRanker
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("MainPage");
		}

		protected override void RegisterTypes()
		{
            Container.RegisterTypeForNavigation<AuthPage, AuthPageViewModel>();
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<MainPage>();
		}
	}
}
