using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Model.Dtos.User;
    using Business.Service.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController(
        IValidatorService validatorService,
        IUserService userService
            ) : BaseController(validatorService)
    {

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAll()
        {
            var result = await userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await userService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Register(UserRegisterDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await userService.RegisterAsync(item);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(UserUpdateDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await userService.UpdateAsync(item);
            return Ok(result);
        }

        [HttpPost]
        [Route("changepassword")]
        [Authorize(Roles = "Administrator,Customer")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await userService.ChangePasswordAsync(item);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
