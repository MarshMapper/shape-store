using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Infrastructure.Repositories
{
    // generic repository base class implementation that handles CRUD operations.  derived classes
    // can add more specific methods if needed.
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ShapeStoreContext _context;
        public Repository(ShapeStoreContext context)
        {
            _context = context;
        }
        // get all entities of type T in the database
        public async Task<Result<IReadOnlyCollection<T>>> GetAllAsync()
        {
            try
            {
                return Result<IReadOnlyCollection<T>>.Success(await _context.Set<T>().ToListAsync<T>());
            }
            catch (Exception ex)
            {
                return Result<IReadOnlyCollection<T>>.Error(ex.Message);
            }
        }
        // get a single entity of type T by its id
        public async Task<Result<T>> GetByIdAsync(int id)
        {
            try
            {
                T? entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return Result<T>.NotFound();
                }
                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return Result<T>.Error(ex.Message);
            }
        }
        // add a new entity of type T to the database
        public async Task<Result<T>> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return Result<T>.Error(ex.Message);
            }
        }
        // update an existing entity of type T in the database
        public async Task<Result<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return Result<T>.Error(ex.Message);
            }
        }
        // delete an existing entity of type T from the database based on its id
        public async Task<Result<T>> DeleteAsync(int id)
        {
            try
            {
                T? entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return Result<T>.NotFound();
                }
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return Result<T>.Error(ex.Message);
            }
        }
    }
}
