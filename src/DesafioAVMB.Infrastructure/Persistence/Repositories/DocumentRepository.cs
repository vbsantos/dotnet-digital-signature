using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Domain.Entities;

namespace DesafioAVMB.Infrastructure.Persistence.Repositories;

public class DocumentRepository(ApplicationDbContext context) : Repository<Document>(context), IDocumentRepository
{
}
