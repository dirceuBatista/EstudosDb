
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Catalogo.Api.Models;

public class Data
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("nome")] public string Name { get; set; }

    [BsonElement("idade")] public int Age { get; set; }

    [BsonElement("cidade")] public string City { get; set; }

    [BsonElement("estado")] public string State { get; set; }
  
}
 
