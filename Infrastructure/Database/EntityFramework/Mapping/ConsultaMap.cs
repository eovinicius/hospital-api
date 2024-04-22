using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;
public class ConsultaMap : IEntityTypeConfiguration<Consulta>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Consulta> builder)
    {
        builder.ToTable("Consultas");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DataHora);
        builder.Property(x => x.Valor);
        builder.Property(x => x.PacienteId);
        builder.Property(x => x.MedicoId);
        builder.Property(x => x.Status);

        builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);
        builder.HasOne(x => x.Medico).WithMany(x => x.Consultas).HasForeignKey(x => x.MedicoId);
    }
}