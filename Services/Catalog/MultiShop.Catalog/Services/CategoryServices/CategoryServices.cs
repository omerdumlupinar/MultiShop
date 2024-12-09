using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMongoCollection<Category> _CategoryCollection;
        private readonly IMapper _Mapper;

        public CategoryServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _CategoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _Mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _Mapper.Map<Category>(createCategoryDto);
            await _CategoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _CategoryCollection.DeleteOneAsync(i => i.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var data = await _CategoryCollection.Find(İ => true).ToListAsync();
            return _Mapper.Map<List<ResultCategoryDto>>(data);
        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
        {
            var data = await _CategoryCollection.Find<Category>(i => i.CategoryID == id).FirstOrDefaultAsync();
            return _Mapper.Map<GetByIdCategoryDto>(data);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var updateData = _Mapper.Map<Category>(updateCategoryDto);
            await _CategoryCollection.FindOneAndReplaceAsync(i => i.CategoryID == updateCategoryDto.CategoryID, updateData);
        }
    }
}
