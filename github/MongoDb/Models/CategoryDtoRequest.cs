using MongoDb.Data;

namespace MongoDb.Models
{
    public class CategoryDtoRequest
    {
        public string? categoryId { get; set; }
        public string? Code { get; set; }
        public string? SlugName { get; set; }
        public Creator? Creator { get; set; }
    }
}
