using System.Data;
using Catalogo.Api.Models;
using Catalogo.Api.repositories.Abstractions;
using Dapper;
using Microsoft.Data.SqlClient;
using MongoDB.Driver;

namespace Catalogo.Api.repositories;

public class DataRepository : IRepositoryData
{
    private IMongoCollection<Data> _collection;
    private readonly IDbConnection _connection;
    public DataRepository(IMongoCollection<Data> collection, IConfiguration configuration) 
    {
        _collection = collection;
        _connection =  new SqlConnection(configuration.GetConnectionString("SqlServer"));
    }
    public async Task<List<Data>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
    public async Task<Data> GetByIdAsync(int id)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }
    public async Task<int> AddAsync(Data data)
    {
        await _collection.InsertOneAsync(data);
        var sql = "INSERT INTO Data (Id, Nome, Age, City, State) VALUES (@Id, @Name, @Age, @City, @State)";
        return await _connection.ExecuteAsync(sql, data);
    }

}