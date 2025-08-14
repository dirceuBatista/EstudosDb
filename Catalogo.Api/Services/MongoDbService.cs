using Catalogo.Api.Models;
using Catalogo.Api.repositories.Abstractions;
using MongoDB.Driver;

namespace Catalogo.Api.Services;

public class MongoDbService
{
    private IMongoCollection<Counter> _collection;
    private readonly IRepositoryData _repositoryData;
    
    public MongoDbService(IRepositoryData repositoryData, IMongoCollection<Counter>counterCollection)
    {
        _collection = counterCollection;
        _repositoryData = repositoryData;
    }
    public async Task SaveData(Data data)
    {
        data.Id = await GetNextIdAsync();
        await _repositoryData.AddAsync(data);
    }

    public async Task<List<Data>> GetAllAsync()
    {
        return await _repositoryData.GetAllAsync();
    }

    public async Task<Data> GetByIdAsync(int id)
    {
        return await _repositoryData.GetByIdAsync(id);
    }
    
    public async Task<int> GetNextIdAsync()
    {
        var filter = Builders<Counter>.Filter.Eq(c => c.CollectionName, "test");
        var update = Builders<Counter>.Update.Inc(c => c.SequenceValue, 1);
        var options = new FindOneAndUpdateOptions<Counter>
        {
            ReturnDocument = ReturnDocument.After,
            IsUpsert = true,
            Projection = Builders<Counter>.Projection.Exclude("_id")
        };

        var counter = await _collection.FindOneAndUpdateAsync(filter, update, options);
        return counter.SequenceValue;
    }
}
