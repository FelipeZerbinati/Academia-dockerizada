using Academia10.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Academia10.Data.Postgres.Context;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
    public DbSet<Academia> Academia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Use o diretório base do projeto
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DatabasePostGres");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A conexão com o banco de dados não foi configurada corretamente.");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
