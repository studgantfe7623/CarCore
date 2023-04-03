using MongoDB.Driver;
using Carcode.Models;

string connectionString = "mongodb://127.0.0.1:27017";
string databaseName = "carcore_db";
string collectionName = "cars";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<Car>(collectionName);

var car = new Car { make = "BMW", model = "320i" };

await collection.InsertOneAsync(car);

var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())
{
    Console.WriteLine($"{result.Id}: {result.make} {result.model}");
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
