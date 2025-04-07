namespace API.Business.Service.Contracts
{
    using Utility.Results.Contracts;
    using Model.Dtos.User;

    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();

        Task<UserResponseDto> GetByIdAsync(int id);

        Task<IDialogResult> RegisterAsync(UserRegisterDto item);

        Task<IDialogResult> UpdateAsync(UserUpdateDto item);

        Task<IDialogResult> ChangePasswordAsync(ChangePasswordDto item);

        Task<IDialogResult> DeleteAsync(int id);
    }
}
