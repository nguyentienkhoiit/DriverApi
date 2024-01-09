using MongoDb.Models;

namespace MongoDb.Services
{
    public interface CategoryServices
    {
        public Task<List<CategoryDtoResponse>> GetAll();
    }
}
