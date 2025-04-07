using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Business.Service.Concrete
{
    using Abstracts;
    using Contracts;
    using Model.Dtos.Response;
    using Persistence.Data;
    using Model.Entities;
    using Utility.Constants.Messages;
    using Utility.Exceptions;
    using Model.Dtos.Jwt;

    public class TokenService:Base, ITokenService
    {
        private readonly UserManager<User> _userManager;

        #region Constructor
        public TokenService(
            IUnitOfWork uow,
            UserManager<User> userManager
            ) :base(uow)
        {
            _userManager = userManager;
        }
        #endregion

        public async Task<TokenResponseDto> CreateTokenAsync(CreateTokenDto item)
        {
            var user = await _userManager.FindByEmailAsync(item.Email);
            
            if (user == null) throw new NotFoundException(UserMessage.UserNotFound);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, item.Password);
            if (!isPasswordValid) throw new AuthenticationException(UserMessage.Login.InvalidUsernameOrPassword);

            var role = await _userManager.GetRolesAsync(user);

            var token = await GetToken(user, role.ToArray());

            return token;
        }

        private async Task<TokenResponseDto> GetToken(User user, string[] roles)
        {
            var jwtSettings = await _uow.JwtSettings.GetAsync(q => q.IsActive);
            if (jwtSettings is null) return null;

            int expireMinutes = jwtSettings.DurationInMinutes;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                new Claim("Roles", string.Join(",", roles)),
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var secret = Encoding.ASCII.GetBytes(jwtSettings.Key);

            var jwtToken = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            if (string.IsNullOrEmpty(token)) throw new BusinessException();

            return new TokenResponseDto
            {
                AccessToken = token,
                ExpiresIn = expireMinutes,
                TokenType = "bearer",
                Roles = roles
            };
        }

        public JwtSettings GetJwtSettings() => _uow.JwtSettings.Get(q => q.IsActive);
    }
}
