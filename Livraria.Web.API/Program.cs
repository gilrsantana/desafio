
using Livraria.Context.Data;
using Livraria.Repository.Interfaces;
using Livraria.Repository.Repositories;
using Livraria.Service.Interfaces;
using Livraria.Service.Services;
using Livraria.Web.API.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder
                        .Configuration
                        .GetConnectionString("DefaultConnection"), 
                        b => 
                        b.MigrationsAssembly("Livraria.Web.API")));

builder.Services.AddAutoMapper(typeof(EntitiesToVMMappingProfile));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
