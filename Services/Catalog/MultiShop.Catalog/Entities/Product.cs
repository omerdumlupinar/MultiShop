using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
<<<<<<< HEAD
        public string ProductID { get; set; }
=======
        public string ProductId { get; set; }
>>>>>>> 80a06ffd4e1c542db60c9b10add359602348c850
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductImageUrl { get; set; }
        public int ProductDescription { get; set; }
        public string CategoryId { get; set; }
        
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
