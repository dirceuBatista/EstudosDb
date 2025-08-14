using Catalogo.Api.Models;
using Catalogo.Api.repositories.Abstractions;
using MongoDB.Driver;

namespace Catalogo.Api.repositories;

public class DataRepository(IMongoCollection<Data> collection) : IRepositoryData
{
    public async Task<List<Data>> GetAllAsync()
    {
        return await collection.Find(_ => true).ToListAsync();
    }
    public async Task<Data> GetByIdAsync(string id)
    {
        return await collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }
    public async Task AddAsync(Data data)
    {
        await collection.InsertOneAsync(data);
    }


}