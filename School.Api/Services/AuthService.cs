using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Api.Authentication;
using School.Api.Contracts.Authentication;
using School.Api.Entities;
using School.Api.Persistence;

namespace School.Api.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IJwtProvider jwtProvider) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly ApplicationDbContext _context = context;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<(AuthResponse?,string?)> GetTokenAsync(string phone, string password, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.PhoneNumber == phone);
            if (user is null)
                return (null, "Invalid phone number / password");

            //if (user.IsDisabled)
            //    return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

            var isValidUser = await _userManager.CheckPasswordAsync(user, password);
            if(!isValidUser)
                return (null, "Invalid phone number / password");

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            var result = new AuthResponse { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Role = "Admin", Token = token, ExpirsIn = expiresIn };

            return (result, null);

        }

        public async Task<string?> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var phoneIsExist = await _userManager.Users.AnyAsync(x=>x.PhoneNumber == request.PhoneNumber);
            if (phoneIsExist)
                return "Phone number is exist";
            var user = new ApplicationUser
            {
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.PhoneNumber,
                Email = request.FirstName + request.PhoneNumber + "@gmail.com"
            };
            var result = await _userManager.CreateAsync(user,request.Password);
            if (result.Succeeded)
                return null;
            return result.Errors.First().Description;
        }
    }
}