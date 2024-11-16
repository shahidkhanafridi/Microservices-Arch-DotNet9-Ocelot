using JwtAuth.Models;
using JwtConfigs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuth.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly List<User> _users =
        [
            new User("admin", "admin", "Admin", ["users.read", "users.write", "posts.read", "posts.write"]),
            new User("user", "user", "User", null),
            new User("userAuther", "userAuther", "Auther", ["users.write"]),
            new User("userReader", "userReader", "Reader", ["users.read"]),
            new User("userModerator", "userModerator", "Moderator", ["users.read", "users.write"]),
            new User("postAuther", "postAuther", "Auther", ["posts.write"]),
            new User("postReader", "postReader", "Reader", ["posts.read"]),
            new User("postModerator", "postModerator", "Moderator", ["posts.read", "posts.write"])
        ];

        public JwtAuthTokenResponse GenerateAuthToken(LoginRequest loginRequest)
        {
            var user = _users.FirstOrDefault(x => x.Username == loginRequest.Username && x.Password == loginRequest.Password);

            if (user == null)
            {
                return new JwtAuthTokenResponse(string.Empty, 0);
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingcredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(10);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Name, user.Username),
                new("Role", user.Role),
                new("scope", (user.Scopes!=null? string.Join(" ", user.Scopes): ""))
            };

            var tokenOptions = new JwtSecurityToken
                (
                    issuer: JwtExtensions.ValidIssuer,
                    claims: claims,
                    expires: expirationTimeStamp,
                    signingCredentials: signingcredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new JwtAuthTokenResponse(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }
    }
}
