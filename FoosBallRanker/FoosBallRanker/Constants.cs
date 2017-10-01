using System;
namespace FoosBallRanker
{
    public static class Constants
    {
        public static string AppName = "FoosBallRanker";

        // OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string iOSClientId = "986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr.apps.googleusercontent.com";
        public static string AndroidClientId = "986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr.apps.googleusercontent.com";

        // These values do not need changing
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string iOSRedirectUrl = $"com.googleusercontent.apps.986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr:/oauth2redirect";
        public static string AndroidRedirectUrl = $"com.googleusercontent.apps.986092384105-j78cc3qbb5j729f2pntva5sq131tvnvr:/oauth2redirect";
    }
}
