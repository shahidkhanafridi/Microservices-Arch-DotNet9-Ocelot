using JwtAuth.Models;

namespace JwtAuth.Services
{
    public interface IJwtTokenService
    {
        JwtAuthTokenResponse GenerateAuthToken(LoginRequest loginRequest);
    }
}
