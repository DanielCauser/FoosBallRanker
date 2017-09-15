using System;
using FoosBallRanker.Services.Authentication;
using Xamarin.Forms;
using Prism.Mvvm;
using Prism.Navigation;

namespace FoosBallRanker.ViewModels
{
	public class AuthPageViewModel : BindableBase, INavigationAware
	{

		private WebView _authWebView;
		public WebView AuthWebView
		{
			get { return _authWebView; }
			set { SetProperty(ref _authWebView, value); }
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			var authType = parameters.GetValue<string>("Auth");
			if (authType == "Google")
				AuthWebView = new GoogleLoginService().Execute();
			else if (authType == "Facebook")
				AuthWebView = new FacebookLoginService().Execute();
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{

		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}
	}
}
