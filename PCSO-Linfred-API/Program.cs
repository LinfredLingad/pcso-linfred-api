
using PCSO_Linfred_API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

MessageManager messageManager = new MessageManager();

app.MapGet("Hello", () => "Hello from dotnet six API");
app.MapGet("Product", () => "Get some Product from AZURE SQL");

app.MapPost("Product", (Product p) => "");
app.MapDelete("Product", (string name) => "Deleted");

app.MapGet("Chat", () => messageManager?.Messages);
app.MapPost("Chat", (Message msg) => messageManager?.Messages?.Add(msg));


app.Run();

// Some Data Contracts
public record class Message(string Name, string Msg);
public record class Product(string Name, string Picture, int Price);

