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
        private readonly INavigationService _navigationService;

		public MainPageViewModel(INavigationService navigationService)
		{
            _navigationService = navigationService;
			LoginWithFacebookCommand = new DelegateCommand(Login);
		}

        private void Login()
        {
            //TODO: call service
            _navigationService.NavigateAsync("NavigationPage/AuthPage");
        }
	}
}
