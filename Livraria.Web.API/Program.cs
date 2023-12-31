
using Livraria.Context.Data;
using Livraria.Repository.Interfaces;
using Livraria.Repository.Repositories;
using Livraria.Service.Interfaces;
using Livraria.Service.Services;
using Livraria.Web.API.Mappings;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(connectionString, 
                        b => 
                        b.MigrationsAssembly("Livraria.Web.API")));

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
       .Enrich.FromLogContext()
          .WriteTo.MSSqlServer(connectionString, 
                 sinkOptions: new MSSqlServerSinkOptions
                 {
            AutoCreateSqlTable = true,
            TableName = "Logs"
        }));

builder.Services.AddAutoMapper(typeof(EntitiesToVMMappingProfile));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
