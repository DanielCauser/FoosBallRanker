using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using FoosBallRanker.Services.Authentication;

namespace FoosBallRanker.Droid
{
        [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
        [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[] { "com.googleusercontent.apps.986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr" },
        DataPath = "/oauth2redirect")]
        public class CustomUrlSchemeInterceptorActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                // Convert Android.Net.Url to Uri
                var uri = new Uri(Intent.Data.ToString());

                // Load redirectUrl page
                AuthenticationState.Authenticator.OnPageLoading(uri);

                Finish();
            }
        }
}
