
using Catalogo.Api.Models;
using Catalogo.Api.repositories;
using Catalogo.Api.repositories.Abstractions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  
var connectionString = "mongodb://admin:senha123@localhost:27017";
var client = new MongoClient(connectionString);
var database = client.GetDatabase("TESt"); 
builder.Services.AddSingleton(database.GetCollection<Data>("test"));
builder.Services.AddSingleton<IRepositoryData, DataRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();   
app.Run();




