namespace SistemaHospitalar.Application.UseCases
{
    public interface IUseCase<Input, Output>
    {
        Task<Output> Handle(Input input);
    }
}