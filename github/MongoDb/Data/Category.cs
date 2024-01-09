using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDb.Data
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("category_id")]
        public string? categoryId { get; set; }

        [BsonElement("code")]
        public string? Code { get; set; }

        [BsonElement("slug_name")]
        public string? SlugName { get; set; }

        [BsonElement("creator_info")]
        public Creator? Creator { get; set; }

    }
}
