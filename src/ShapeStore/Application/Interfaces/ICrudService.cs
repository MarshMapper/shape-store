using Ardalis.Result;

namespace ShapeStore.Application.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        Task<Result<IReadOnlyCollection<T>>> GetAllAsync();
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(int id);
    }
}
