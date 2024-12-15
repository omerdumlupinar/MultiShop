using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public class ProductImageService : IProductImageService
    {

        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var databse = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = databse.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateProductImageDto createProductImageDto)
        {
            var addData = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(addData);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(i => i.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllCategoryAsync()
        {
            var data = await _productImageCollection.Find(i => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(data);
        }

        public async Task<GetByIdProductImageDto> GetCategoryByIdAsync(string id)
        {
            var data = await _productImageCollection.Find<ProductImage>(i => i.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(data);
        }

        public async Task UpdateCategoryAsync(UpdateProductImageDto updateProductImageDto)
        {
            var updateData = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(i => i.ProductImageID == updateProductImageDto.ProductImageID, updateData);
        }
    }
}