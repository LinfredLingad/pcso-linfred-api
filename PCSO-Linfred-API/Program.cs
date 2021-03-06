
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.SignalR;


//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddSignalR();

//var app = builder.Build();
//app.UseSwagger();
//app.UseSwaggerUI();
//app.UseHttpsRedirection();

//app.MapHub<Chat>(nameof(Chat));

//app.MapGet("/", () => "Hello World!");

//app.MapGet("/todoitems", async (TodoDb db) =>
//    await db.Todos.ToListAsync());

//app.MapGet("/todoitems/complete", async (TodoDb db) =>
//    await db.Todos.Where(t => t.IsComplete).ToListAsync());

//app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
//    await db.Todos.FindAsync(id)
//        is Todo todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

//app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();

//    return Results.Created($"/todoitems/{todo.Id}", todo);
//});

//app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
//{
//    var todo = await db.Todos.FindAsync(id);

//    if (todo is null) return Results.NotFound();

//    todo.Name = inputTodo.Name;
//    todo.IsComplete = inputTodo.IsComplete;

//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});

//app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
//{
//    if (await db.Todos.FindAsync(id) is Todo todo)
//    {
//        db.Todos.Remove(todo);
//        await db.SaveChangesAsync();
//        return Results.Ok(todo);
//    }

//    return Results.NotFound();
//});

//app.MapDelete("/todoitems", async (TodoDb db) =>
//{
//    await db.Database.EnsureDeletedAsync();
//    await db.SaveChangesAsync();
//    return Results.Ok(null);
//});


//app.Run();

//public class Chat : Hub
//{
//    public void Broadcast(string name, string message)
//    {
//        Clients.All.SendAsync("Receive", name, message);
//    }
//}

//class Todo
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public bool IsComplete { get; set; }
//    public string? Message { get; set; }
//    public DateTime? Created { get; set; }
//}

//class TodoDb : DbContext
//{
//    public TodoDb(DbContextOptions<TodoDb> options)
//        : base(options) { }

//    public DbSet<Todo> Todos => Set<Todo>();
//}

using PCSO_Linfred_API.Data;
using Microsoft.EntityFrameworkCore;



var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();



app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();



app.UseRouting();



app.UseAuthorization();



app.MapControllers();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.Run();