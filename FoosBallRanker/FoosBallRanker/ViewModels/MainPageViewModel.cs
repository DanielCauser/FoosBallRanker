using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using FoosBallRanker.Services.Authentication;
using Xamarin.Forms;

namespace FoosBallRanker.ViewModels
{
	public class MainPageViewModel : BindableBase
    {
        public WebView Auth { get; set; }

		public DelegateCommand LoginWithFacebookCommand { get; set; }

		public DelegateCommand LoginWithGoogleCommand { get; set; }

		private readonly INavigationService _navigationService;

		public MainPageViewModel(INavigationService navigationService)
		{
            _navigationService = navigationService;
			LoginWithFacebookCommand = new DelegateCommand(LoginFacebook);
			LoginWithGoogleCommand = new DelegateCommand(LoginGoogle);
		}

        private void LoginFacebook()
        {
			var pm = new NavigationParameters("Auth=Facebook");
			_navigationService.NavigateAsync("NavigationPage/AuthPage", pm);
        }

		private void LoginGoogle()
		{
			var pm = new NavigationParameters("Auth=Google");
			_navigationService.NavigateAsync("NavigationPage/AuthPage", pm);
		}
	}
}
