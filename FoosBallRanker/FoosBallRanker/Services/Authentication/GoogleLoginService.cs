using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoosBallRanker.Services.Authentication
{
	public class GoogleLoginService
	{

		public static readonly string ClientId = "986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr.apps.googleusercontent.com";
		public static readonly string ClientSecret = "89jPTee_PnSPFqCG68OrXD0h";
		public static readonly string RedirectUri = "https://www.google.com/";

		public WebView Execute()
		{
			var authRequest =
				  "https://accounts.google.com/o/oauth2/v2/auth"
				  + "?response_type=code"
				  + "&scope=openid"
				  + "&redirect_uri=" + RedirectUri
				  + "&client_id=" + ClientId;

			var webView = new WebView
			{
				Source = authRequest,
				HeightRequest = 1
			};

			webView.Navigated += WebViewOnNavigated;

			return webView;
		}

		private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
		{
			var code = ExtractCodeFromUrl(e.Url);

			if (code != "")
			{
				//var accessToken = await _googleViewModel.GetAccessTokenAsync(code);
				var accessToken = await GetAccessTokenAsync(code);

				//await _googleViewModel.SetGoogleUserProfileAsync(accessToken);

				//SetPageContent(_googleViewModel.GoogleProfile);
			}
		}

		private string ExtractCodeFromUrl(string url)
		{
			if (url.Contains("code="))
			{
				var attributes = url.Split('&');

				var code = attributes.FirstOrDefault(s => s.Contains("code=")).Split('=')[1];

				return code;
			}

			return string.Empty;
		}

		public async Task<string> GetAccessTokenAsync(string code)
		{
			var requestUrl =
				"https://www.googleapis.com/oauth2/v4/token"
				+ "?code=" + code
				+ "&client_id=" + ClientId
				+ "&client_secret=" + ClientSecret
				+ "&redirect_uri=" + RedirectUri
				+ "&grant_type=authorization_code";

			var httpClient = new HttpClient();

			var response = await httpClient.PostAsync(requestUrl, null);

			var json = await response.Content.ReadAsStringAsync();

			//var accessToken = JsonConvert.DeserializeObject<JObject>(json).Value<string>("access_token");
			var accessToken =  await httpClient.GetStringAsync(requestUrl);
			return accessToken;
		}

		//public async Task<GoogleProfile> GetGoogleUserProfileAsync(string accessToken)
		public async Task GetGoogleUserProfileAsync(string accessToken)
		{

			var requestUrl = "https://www.googleapis.com/plus/v1/people/me"
							 + "?access_token=" + accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);

			//var googleProfile = JsonConvert.DeserializeObject<GoogleProfile>(userJson);

			//return googleProfile;
		}
	}
}
