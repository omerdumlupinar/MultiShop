using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
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


        public async Task CreateCategoryAsync(CreateProductDto createProductDto)
        {
            var addData=_mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(addData);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _productCollection.DeleteOneAsync(i => i.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllCategoryAsync()
        {
            var data = await _productCollection.Find(i => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(data);
        }

        public async Task<GetByIdProductDto> GetCategoryByIdAsync(string id)
        {
            var data = await _productCollection.Find<Product>(i => i.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(data);
        }

        public async Task UpdateCategoryAsync(UpdateProductDto updateProductDto)
        {
            var updateData = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(i => i.ProductID == updateProductDto.ProductID, updateData); 
        }
    }
}
