using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Domain.Entities;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class SignatoryRepository(ApplicationDbContext context) : Repository<Signatory>(context), ISignatoryRepository
{
}
