using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Repositories;

public interface IRepository<T> where T : class
{
    DbSet<T> Set();

    IQueryable<T> AsNoTracking();

    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
