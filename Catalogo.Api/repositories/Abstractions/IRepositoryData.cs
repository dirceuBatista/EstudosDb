using Catalogo.Api.Models;

namespace Catalogo.Api.repositories.Abstractions;

public interface IRepositoryData
{
    Task<List<Data>> GetAllAsync();
    Task<Data> GetByIdAsync(string id);
    Task AddAsync(Data data);
}