using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateProductDto createProductDto);
        Task UpdateCategoryAsync(UpdateProductDto updateProductDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdProductDto> GetCategoryByIdAsync(string id);
    }
}
