using Microsoft.EntityFrameworkCore;
using ReceitasApi.Data; // Namespace do seu contexto de dados
using ReceitasApi.Models; // Namespace dos seus modelos
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllers();

// Configurar o DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeando os controladores
app.MapControllers();

// Adicionar endpoints para Receitas
app.MapGet("/api/receitas", async (DataContext context) =>
{
    return await context.Receitas.Include(r => r.Categoria).ToListAsync();
})
.WithName("GetReceitas");

app.MapGet("/api/receitas/{id}", async (int id, DataContext context) =>
{
    return await context.Receitas.Include(r => r.Categoria).FirstOrDefaultAsync(r => r.Id == id)
        is Receita receita
            ? Results.Ok(receita)
            : Results.NotFound();
})
.WithName("GetReceita");

app.MapPost("/api/receitas", async (Receita receita, DataContext context) =>
{
    context.Receitas.Add(receita);
    await context.SaveChangesAsync();
    return Results.Created($"/api/receitas/{receita.Id}", receita);
})
.WithName("CreateReceita");

app.Run();