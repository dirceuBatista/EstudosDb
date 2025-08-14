using Catalogo.Api.Models;

namespace Catalogo.Api.repositories.Abstractions;

public interface IRepositoryData
{
    Task<List<Data>> GetAllAsync();
    Task<Data> GetByIdAsync(int id);
    Task<int> AddAsync(Data data);
    
}