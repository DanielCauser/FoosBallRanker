using System;
using FoosBallRanker.Services.Authentication;
using Xamarin.Forms;
using Prism.Mvvm;

namespace FoosBallRanker.ViewModels
{
    public class AuthPageViewModel : BindableBase
	{

		private WebView _authWebView;
		public WebView AuthWebView
		{
			get { return _authWebView; }
			set { SetProperty(ref _authWebView, value); }
		}

        public AuthPageViewModel()
        {
            AuthWebView = new FacebookLoginService().Execute();
        }
    }
}
