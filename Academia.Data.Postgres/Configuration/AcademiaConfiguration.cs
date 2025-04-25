using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Academia10.Domain.Models;

namespace Academia10.Data.Postgres.Configuration;

public class AcademiaConfiguration : IEntityTypeConfiguration<Academia>
{
    public void Configure(EntityTypeBuilder<Academia> builder)
    {
        builder.ToTable("Academia10");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome);
    }
}
