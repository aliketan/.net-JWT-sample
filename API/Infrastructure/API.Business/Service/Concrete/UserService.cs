using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Business.Service.Concrete
{
    using Contracts;
    using Utility.Results.Concrete;
    using Utility.Results.Contracts;
    using Model.Entities;
    using Enums.ComplexTypes;
    using Utility.Constants.Messages;
    using Model.Dtos.User;
    using Abstracts;
    using Persistence.Data;
    using Utility.Extensions;

    public class UserService : Base, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        #region Constructor
        public UserService(
            UserManager<User> userManager,
            IMapper mapper,
            IUnitOfWork uow
            ):base(uow)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        private async Task<User> GetById(int id) => await _uow.User.GetByIdAsync(id);

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var list = await _uow.User.GetAllAsync();
            return _mapper.Map<List<UserResponseDto>>(list);
        }

        public async Task<UserResponseDto> GetByIdAsync(int id)
        {
            var list = await _uow.User.GetByIdAsync(id);
            return _mapper.Map<UserResponseDto>(list);
        }

        public async Task<IDialogResult> RegisterAsync(UserRegisterDto item)
        {
            var data = _mapper.Map<User>(item);
            data.UserName = item.Email;

            var isUserExists = await _userManager.FindByEmailAsync(item.Email);
            if(isUserExists is not null)
                return new DialogResult(ResultStatus.Error, UserMessage.Register.AlreadyExists);

            var result = await _userManager.CreateAsync(data, item.Password);
            if (!result.Succeeded)
                return new DialogResult(ResultStatus.Error);

            if(!item.Roles.All(q => q.IsEnum<Enums.User.Role>()))
                return new DialogResult(ResultStatus.Error, UserMessage.Register.InvalidUserRole);

            _ = await _userManager.AddToRolesAsync(data, item.Roles);
            return new DialogResult(ResultStatus.Success, UserMessage.Register.Success);
        }

        public async Task<IDialogResult> UpdateAsync(UserUpdateDto item)
        {
            var user = await GetById(item.Id);
            if (user is null)
                return new DialogResult(ResultStatus.Error, UserMessage.UserNotFound);

            var data = _mapper.Map(item, user);

            var isOk = await _uow.User.UpdateAsync(data).ContinueWith(_ => _uow.SaveAsync());

            if (!await isOk)
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success, UserMessage.Update.Success);
        }

        public async Task<IDialogResult> ChangePasswordAsync(ChangePasswordDto item)
        {
            var user = await GetById(item.Id);
            if (user is null)
                return new DialogResult(ResultStatus.Error, UserMessage.UserNotFound);

            var result = await _userManager.ChangePasswordAsync(user, item.CurrentPassword, item.NewPassword);

            if (!result.Succeeded)
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success, UserMessage.Update.PasswordChanged);
        }

        public async Task<IDialogResult> DeleteAsync(int id)
        {
            var user = await GetById(id);
            if (user is null)
                return new DialogResult(ResultStatus.Error, UserMessage.UserNotFound);

            await _uow.User.DeleteByIdAsync(id);
            if (!await _uow.SaveAsync())
                return new DialogResult(ResultStatus.Error);

            return new DialogResult(ResultStatus.Success);
        }
    }
}
