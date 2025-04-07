namespace API.Business.Service.Abstracts
{
    using Persistence.Data;

    public abstract class Base
    {
        protected readonly IUnitOfWork _uow;

        #region Constructor
        protected Base(
            IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        #endregion
    }
}
