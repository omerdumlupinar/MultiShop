using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateCategoryAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdProductDetailDto> GetCategoryByIdAsync(string id);
    }
}
