using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Model.Dtos.Jwt;
    using Business.Service.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController(
        IValidatorService validatorService,
        ITokenService tokenService
            ) : BaseController(validatorService)
    {
        [HttpPost]
        public async Task<IActionResult> Token(CreateTokenDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await tokenService.CreateTokenAsync(item);
            return Ok(result);
        }
    }
}
