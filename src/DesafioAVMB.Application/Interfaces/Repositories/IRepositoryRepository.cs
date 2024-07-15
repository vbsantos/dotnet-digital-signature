using DesafioAVMB.Domain.Entities;

namespace DesafioAVMB.Application.Interfaces.Repositories;

public interface IRepositoryRepository : IRepository<Repository>
{
    public Task<List<Repository>> GetRepositoriesByUserIdAsync(Guid userId);
}
