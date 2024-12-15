using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {

        private readonly IMongoCollection<ProductDetail> _productDetailsCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailsCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailsCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _productDetailsCollection.DeleteOneAsync(i => i.ProductDetailID== id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllCategoryAsync()
        {
            var data = await _productDetailsCollection.Find(İ => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(data);
        }

        public async Task<GetByIdProductDetailDto> GetCategoryByIdAsync(string id)
        {
            var data = await _productDetailsCollection.Find<ProductDetail>(i => i.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(data);
        }

        public async Task UpdateCategoryAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var updateData = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailsCollection.FindOneAndReplaceAsync(i => i.ProductDetailID == updateProductDetailDto.ProductDetailID, updateData);
        }
    }
}
