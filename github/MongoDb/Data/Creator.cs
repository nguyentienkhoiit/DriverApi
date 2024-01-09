using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Data
{
    public class Creator
    {
        [BsonElement("user_id")]
        public string? UserId { get; set; }

        [BsonElement("role_id")]
        public string? RoleId { get; set;}

        [BsonElement("username")]
        public string? UserName { get; set; }
    }
}
