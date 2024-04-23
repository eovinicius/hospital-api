using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;

public class LaudoMap : IEntityTypeConfiguration<Laudo>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Laudo> builder)
    {
        builder.ToTable("Laudos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Descricao);
        builder.Property(x => x.ExameId);

        builder.HasOne(x => x.Exame)
            .WithOne(x => x.Laudo)
            .HasForeignKey<Laudo>(x => x.ExameId);

    }
}