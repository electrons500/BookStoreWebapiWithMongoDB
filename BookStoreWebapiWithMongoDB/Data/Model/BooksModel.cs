using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookStoreWebapiWithMongoDB.Data.Model
{
    [BsonIgnoreExtraElements]
    public class BooksModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        
        public double Price { get; set; }
       
        public string Category { get; set; }
      
        public string Author { get; set; }
    }
}
