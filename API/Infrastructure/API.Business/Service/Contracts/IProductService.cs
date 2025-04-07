namespace API.Business.Service.Contracts
{
    using Model.Dtos.Product;
    using Utility.Results.Contracts;

    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllAsync();

        Task<ProductResponseDto> GetByIdAsync(int id);

        Task<IDialogResult> AddAsync(AddProductDto item);

        Task<IDialogResult> UpdateAsync(UpdateProductDto item);

        Task<IDialogResult> DeleteAsync(int id);
    }
}
