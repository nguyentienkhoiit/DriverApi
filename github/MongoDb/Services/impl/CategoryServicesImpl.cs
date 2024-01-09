using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDb.Configuration;
using MongoDb.Data;
using MongoDb.Models;
using MongoDB.Driver;

namespace MongoDb.Services.impl
{
    public class CategoryServicesImpl : CategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryServicesImpl(IOptions<DatabaseSettings> databaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _categoryCollection = mongoDb.GetCollection<Category>(databaseSettings.Value.CollectionName);
            _mapper = mapper;
        }

        public async Task<List<CategoryDtoResponse>> GetAll()
        {
            var categories = await _categoryCollection.Find(_ =>  true).ToListAsync();
            return _mapper.Map<List<CategoryDtoResponse>>(categories);
        }
    }
}
