using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo.Api.Models;

[BsonIgnoreExtraElements]
public class Counter
{
    public string CollectionName { get; set; }
    public int SequenceValue { get; set; }
}
