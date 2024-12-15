using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateProductImageDto createProductImageDto);
        Task UpdateCategoryAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdProductImageDto> GetCategoryByIdAsync(string id);
    }
}
