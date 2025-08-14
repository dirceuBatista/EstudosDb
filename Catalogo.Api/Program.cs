
using Catalogo.Api.Models;
using Catalogo.Api.repositories;
using Catalogo.Api.repositories.Abstractions;
using Catalogo.Api.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  

var connectionStringSql = builder.Configuration.GetConnectionString("SqlServer");


var connectionString = "mongodb://admin:senha123@localhost:27017";
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient(connectionString);
});
builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("TESt"); 
});
builder.Services.AddSingleton(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<Data>("test");
});
builder.Services.AddSingleton(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<Counter>("Counter");
});
builder.Services.AddSingleton<IRepositoryData, DataRepository>();
builder.Services.AddSingleton<MongoDbService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();   
app.Run();




