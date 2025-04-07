namespace API.Business.Service.Concrete
{
    using Abstracts;
    using Contracts;
    using Persistence.Data;
    using Model.Entities;

    public class JwtService : Base, IJwtService
    {
        #region Constructor
        public JwtService(
            IUnitOfWork uow
            ) :base(uow)
        {
           
        }
        #endregion

        public JwtSettings GetJwtSettings() => _uow.JwtSettings.Get(q => q.IsActive);
    }
}
