using Microsoft.EntityFrameworkCore;
using Tarefas.Repository;
using Tarefas.Data;

var builder = WebApplication.CreateBuilder(args);


// Adicionar suporte a controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar EF Core com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tarefas.db"));

builder.Services.AddScoped<TarefaRepository>();

var app = builder.Build();


// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // 👈 Habilita Controllers

app.Run();
