using Academia10.Application.Service;
using Academia10.Data.Postgres.Context;
using Academia10.Data.Repository;
using Academia10.Domain.Interfaces.Repository;
using Academia10.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DatabasePostGres");
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAcademiaService, AcademiaService>();


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
