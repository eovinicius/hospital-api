using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;
public class ConvenioMap : IEntityTypeConfiguration<Convenio>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Convenio> builder)
    {
        builder.ToTable("Convenios");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome);
        builder.Property(x => x.Cnpj);
        builder.Property(x => x.Ativo);
    }
}