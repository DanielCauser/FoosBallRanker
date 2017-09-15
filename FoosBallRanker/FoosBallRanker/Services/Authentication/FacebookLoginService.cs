using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoosBallRanker.Services.Authentication
{
    public class FacebookLoginService
    {
		private string ClientId = "1996769407204399";

		public WebView Execute()
		{
			//https://www.facebook.com/v2.10/dialog/oauth?client_id=1996769407204399&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html
			var apiRequest = $"https://www.facebook.com/v2.10/dialog/oauth?client_id={ClientId}&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

			var webView = new WebView
			{
				Source = apiRequest,
				HeightRequest = 1
			};

			webView.Navigated += WebViewOnNavigated;

            return webView;
		}

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
		{

			var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (!string.IsNullOrEmpty(accessToken))
                await GetFacebookProfileAsync(accessToken);
		}

		private string ExtractAccessTokenFromUrl(string url)
		{
			if (url.Contains("access_token") && url.Contains("&expires_in="))
			{
				var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

				var accessToken = at.Remove(at.IndexOf("&expires_in="));

				return accessToken;
			}

			return string.Empty;
		}
		public async Task GetFacebookProfileAsync(string accessToken)
		{
			var requestUrl =
				"https://graph.facebook.com/v2.7/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,bio,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
				+ accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);
		}
    }
}
