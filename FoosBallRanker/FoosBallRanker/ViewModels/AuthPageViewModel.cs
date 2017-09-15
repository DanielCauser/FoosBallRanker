using System;
using FoosBallRanker.Services.Authentication;
using Xamarin.Forms;

namespace FoosBallRanker.ViewModels
{
    public class AuthPageViewModel
    {
        public WebView AuthWebView;

        public AuthPageViewModel()
        {
            AuthWebView = new FacebookLoginService().Execute();
        }
    }
}
