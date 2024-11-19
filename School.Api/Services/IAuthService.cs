using School.Api.Contracts.Authentication;

namespace School.Api.Services
{
    public interface IAuthService
    {
        Task<(AuthResponse?, string?)> GetTokenAsync(string phone, string password,CancellationToken cancellationToken=default);
        Task<string?> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    }
}
