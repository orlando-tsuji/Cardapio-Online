using Microsoft.OpenApi;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Services;
using backend.Services.Interfaces;
using backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CardapioDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cardápio Online API",
        Version = "v1"
    });
});

builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Cardápio Online API v1");

        options.RoutePrefix = "swagger";
        options.DocumentTitle = "Cardápio Online API";
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

