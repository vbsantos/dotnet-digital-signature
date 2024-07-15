using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class RepositoryRepository(ApplicationDbContext context) : Repository<Repository>(context), IRepositoryRepository
{
    private readonly DbSet<Repository> _dbSet = context.Set<Repository>();

    public async Task<List<Repository>> GetRepositoriesByUserIdAsync(Guid userId)
    {
        return await _dbSet.Where(r => r.OwnerId == userId).ToListAsync();
    }
}
