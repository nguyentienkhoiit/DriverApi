using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDb.Data;

namespace MongoDb.Models
{
    public class CategoryDtoResponse
    {
        public string? Id { get; set; }
        public string? categoryId { get; set; }
        public string? Code { get; set; }
        public string? SlugName { get; set; }
        public Creator? Creator { get; set; }
    }
}
