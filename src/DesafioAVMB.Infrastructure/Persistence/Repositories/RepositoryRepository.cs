using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Domain.Entities;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class RepositoryRepository(ApplicationDbContext context) : Repository<Repository>(context), IRepositoryRepository
{
}
