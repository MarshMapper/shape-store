using Ardalis.Result;

namespace ShapeStore.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<Result<IAsyncEnumerable<T>>> GetAllAsync();
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(int id);
    }
}
