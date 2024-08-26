using Ardalis.Result;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Application.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<Result<IReadOnlyCollection<T>>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Result<T>> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Result<T>> AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<Result<T>> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<Result<T>> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
