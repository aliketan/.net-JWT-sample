namespace API.Business.Service.Contracts
{
    using Model.Entities;

    public interface IJwtService
    {
        JwtSettings GetJwtSettings();
    }
}
