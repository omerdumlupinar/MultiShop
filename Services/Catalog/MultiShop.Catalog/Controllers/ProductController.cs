using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var responsData = await _productService.GetAllCategoryAsync();
            return Ok(responsData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var responsData = await _productService.GetCategoryByIdAsync(id);
            return Ok(responsData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateProductDto createProductDto )
        {
            await _productService.CreateCategoryAsync(createProductDto);
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateCategoryAsync(updateProductDto);
            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteCategoryAsync(id);
            return Ok(true);
        }
    }
}
