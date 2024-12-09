using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public Task CreateCategoryAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultProductDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdProductDto> GetCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
