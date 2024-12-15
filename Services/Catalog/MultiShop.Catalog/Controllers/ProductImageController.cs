using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var responsData = await _productImageService.GetAllCategoryAsync();
            return Ok(responsData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var responsData = await _productImageService.GetCategoryByIdAsync(id);
            return Ok(responsData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateCategoryAsync(createProductImageDto);
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateCategoryAsync(updateProductImageDto);
            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteCategoryAsync(id);
            return Ok(true);
        }
    }
}
