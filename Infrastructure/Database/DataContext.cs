using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;

namespace SistemaHospitalar.Infrastructure.Database;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Convenio> Convenios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Exame> Exames { get; set; }
    public DbSet<Retorno> Retornos { get; set; }
    public DbSet<Laudo> Laudos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteMap());
        modelBuilder.ApplyConfiguration(new MedicoMap());
        modelBuilder.ApplyConfiguration(new ConsultaMap());
        modelBuilder.ApplyConfiguration(new ConvenioMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new ExameMap());
        modelBuilder.ApplyConfiguration(new RetornoMap());
        modelBuilder.ApplyConfiguration(new LaudoMap());
    }
}