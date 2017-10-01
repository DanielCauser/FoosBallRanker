using System;
using Xamarin.Auth;

namespace FoosBallRanker.Services.Authentication
{
    public class GoogleLoginService
    {
        public void Execute()
        {
            var authenticator = new OAuth2Authenticator(
                clientId: Constants.AndroidClientId,
                clientSecret: null,
                scope: Constants.Scope,
                authorizeUrl: new Uri(Constants.AuthorizeUrl),
                redirectUrl: new Uri(Constants.AndroidRedirectUrl),
                accessTokenUrl: new Uri(Constants.AccessTokenUrl),
                getUsernameAsync: null,
                isUsingNativeUI: true);

            authenticator.Completed += OnAuthCompleted;

			var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            AuthenticationState.Authenticator = authenticator;
			presenter.Login(authenticator);
        }

        private void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
