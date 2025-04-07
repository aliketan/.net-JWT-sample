using AutoMapper;

namespace API.Business.Service.Concrete
{
    using Contracts;
    using Utility.Results.Concrete;
    using Utility.Results.Contracts;
    using Model.Entities;
    using Enums.ComplexTypes;
    using Utility.Constants.Messages;
    using Abstracts;
    using Persistence.Data;
    using Model.Dtos.Product;

    public class ProductService : Base, IProductService
    {
        private readonly IMapper _mapper;

        #region Constructor
        public ProductService(
            IMapper mapper,
            IUnitOfWork uow
            ):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        private async Task<Product> GetById(int id) => await _uow.Product.GetByIdAsync(id);

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var list = await _uow.Product.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(list);
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var list = await GetById(id);
            return _mapper.Map<ProductResponseDto>(list);
        }

        public async Task<IDialogResult> AddAsync(AddProductDto item)
        {
            var data = _mapper.Map<Product>(item);
            var isOk = await _uow.Product.AddAsync(data).ContinueWith(_ => _uow.SaveAsync());

            if (!await isOk)
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success, ProductMessage.ProductAddedSuccessfully);
        }

        public async Task<IDialogResult> UpdateAsync(UpdateProductDto item)
        {
            var product = await GetByIdAsync(item.Id);
            if(product is null)
                return new DialogResult(ResultStatus.Error, ProductMessage.NotFound);

            var data = _mapper.Map<Product>(item);
            var isOk = await _uow.Product.UpdateAsync(data).ContinueWith(_ => _uow.SaveAsync());

            if (!await isOk)
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success, ProductMessage.ProductUpdatedSuccessfully);
        }

        public async Task<IDialogResult> DeleteAsync(int id)
        {
            var user = await GetById(id);
            if (user is null)
                return new DialogResult(ResultStatus.Error, UserMessage.UserNotFound);

            var isOk = await _uow.Product.DeleteByIdAsync(id).ContinueWith(_ => _uow.SaveAsync());
            if (!await isOk)
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success);
        }
    }
}
