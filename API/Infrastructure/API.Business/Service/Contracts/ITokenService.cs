namespace API.Business.Service.Contracts
{
    using Model.Dtos.Response;
    using Model.Dtos;
    using Model.Entities;
    using API.Model.Dtos.Jwt;

    public interface ITokenService
    {
        Task<TokenResponseDto> CreateTokenAsync(CreateTokenDto item);

        JwtSettings GetJwtSettings();
    }
}
