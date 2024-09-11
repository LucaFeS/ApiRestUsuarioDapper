using Application.Interfaces;
using Application.Mappings;
using Domain.Entidades.Interfaces;
using Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Mapa));

builder.Services.AddScoped<IProdutosService, ProdutosService>();
builder.Services.AddScoped<IProdutoApplication, ProdutoApplication>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaApplication, CategoriaApplication>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

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
