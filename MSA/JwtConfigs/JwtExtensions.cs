using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtConfigs
{
    public static class JwtExtensions
    {
        public const string SecurityKey = "ThisIsMyPersonalSecurityKeyIncludingChars123To890";
        public const string ValidIssuer = "https://localhost:7201";

        public static void AddJwtAuthentications(this IServiceCollection services)
        {
            var keyBytes = Encoding.UTF8.GetBytes(SecurityKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ValidIssuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });
        }
    }
}
