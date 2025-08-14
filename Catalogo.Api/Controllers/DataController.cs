
using Catalogo.Api.Models;
using Catalogo.Api.repositories.Abstractions;
using Catalogo.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Catalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController(MongoDbService service) : ControllerBase
{
    
   [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await service.GetAllAsync();
        return Ok(lista);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await service.GetByIdAsync(id);
        return data == null ? NotFound() : Ok(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Data data)
    {
        await service.SaveData(data);
        return Ok( data);
    }
}