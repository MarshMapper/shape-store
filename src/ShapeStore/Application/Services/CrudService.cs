using Ardalis.Result;
using FluentValidation;
using Ardalis.Result.FluentValidation;

using ShapeStore.Application.Interfaces;

namespace ShapeStore.Application.Services
{
    public abstract class CrudService<T> : ICrudService<T> where T : class
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
        public abstract IValidator<T> GetValidator();

        public virtual Task<Result<T>> AddAsync(T entity)
        {
            IValidator<T> validator = GetValidator();
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return Task.FromResult(Result<T>.Invalid(FluentValidationResultExtensions.AsErrors(validationResult)));
            }
            return _repository.AddAsync(entity);
        }

        public Task<Result<T>> UpdateAsync(T entity)
        {
            IValidator<T> validator = GetValidator();
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return Task.FromResult(Result<T>.Invalid(FluentValidationResultExtensions.AsErrors(validationResult)));
            }
            return _repository.UpdateAsync(entity);
        }

        public Task<Result<T>> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
