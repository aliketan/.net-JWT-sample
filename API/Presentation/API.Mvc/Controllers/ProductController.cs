using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Business.Service.Contracts;
    using Model.Dtos.Product;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:BaseController
    {
        private readonly IProductService _productService;

        #region Constructor
        public ProductController(
            IProductService productService,
            IValidatorService validatorService
            ):base(validatorService)
        {
            _productService = productService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add([FromBody] AddProductDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await _productService.AddAsync(item);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto item)
        {
            var validationResult = await GetValidationResult(item);

            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            var result = await _productService.UpdateAsync(item);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
