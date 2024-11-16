namespace JwtAuth.Models
{
    public class JwtAuthTokenResponse
    {
        public string Token { get; set; }
        public int Expiration { get; set; }

        public JwtAuthTokenResponse(string token, int expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
