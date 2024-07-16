using DesafioAVMB.Application.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    // public void Update(T entity)
    // {
    //     _dbSet.Update(entity);
    // }

    // public void Delete(T entity)
    // {
    //     _dbSet.Remove(entity);
    // }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
