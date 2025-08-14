
using Catalogo.Api.Models;
using Catalogo.Api.repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;


namespace Catalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController(IRepositoryData _data) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _data.GetAllAsync();
        return Ok(lista);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _data.GetByIdAsync(id);
        return data == null ? NotFound() : Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Data data)
    {
        await _data.AddAsync(data);
        return CreatedAtAction(nameof(Get), new { id = data.Id }, data);
    }
}