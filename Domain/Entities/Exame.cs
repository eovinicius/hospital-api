using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Domain.Entities;

public class Exame
{
    public Guid Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public decimal Valor { get; private set; }
    public Guid PacienteId { get; private set; }
    public virtual Paciente? Paciente { get; private set; }
    public Guid MedicoId { get; private set; }
    public virtual Medico? Medico { get; private set; }
    public EStatusAtendimento Status { get; private set; }

    public Exame(DateTime dataHora, decimal valor, Guid pacienteId, Guid medicoId)
    {
        Id = Guid.NewGuid();
        DataHora = dataHora;
        Valor = valor;
        PacienteId = pacienteId;
        MedicoId = medicoId;
        Status = EStatusAtendimento.Agendada;
    }
}