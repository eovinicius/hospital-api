namespace SistemaHospitalar.Application.Repositories;
public interface IRepository<T>
{
    Task Add(T entity);
    Task<T?> GetById(Guid id);
    Task Update(T entity);
    Task<List<T>> GetAll();
}