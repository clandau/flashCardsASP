using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlashCardsAPI.Models 
{
  public class FlashCard
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string SideA { get; set; }
    public string SideB { get; set; }
    public string Category { get; set; }
  }
}