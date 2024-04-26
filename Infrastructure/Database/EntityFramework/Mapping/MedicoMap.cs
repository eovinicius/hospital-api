using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;
public class MedicoMap : IEntityTypeConfiguration<Medico>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medicos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome);
        builder.Property(x => x.Crm);
        builder.HasIndex(x => x.Crm).IsUnique();
        builder.Property(x => x.Especialidade);
        builder.Property(x => x.Ativo);
        // builder.Property(x => x.Consultas);

        builder.HasMany(x => x.Consultas).WithOne(x => x.Medico);
    }
}