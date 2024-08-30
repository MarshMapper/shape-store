using Ardalis.Result;
using ShapeStore.Application.Services;

namespace ShapeStore.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<Result<IReadOnlyCollection<T>>> GetAllAsync();
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(int id);
    }
}
