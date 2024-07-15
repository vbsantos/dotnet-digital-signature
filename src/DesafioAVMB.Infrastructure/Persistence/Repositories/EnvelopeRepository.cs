using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Domain.Entities;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class EnvelopeRepository(ApplicationDbContext context) : Repository<Envelope>(context), IEnvelopeRepository
{
}
