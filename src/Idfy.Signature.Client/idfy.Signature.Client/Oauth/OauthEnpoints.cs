namespace Idfy.Signature.Client.Oauth
{
    internal static class OauthEnpoints
    {
        public static string TokenEndpointTest => "https://oauth2test.signere.com/connect/token";
        public static string TokenEndpointProd => "https://oauth.signere.no/connect/token";
    }

    public enum OauthTokenEndpoint
    {
        SignereTest,
        SignereProd
    }
}