using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductDetailService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var responsData = await _productDetailService.GetAllCategoryAsync();
            return Ok(responsData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var responsData = await _productDetailService.GetCategoryByIdAsync(id);
            return Ok(responsData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateCategoryAsync(createProductDetailDto);
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateCategoryAsync(updateProductDetailDto);
            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteCategoryAsync(id);
            return Ok(true);
        }
    }
}
