using Microsoft.EntityFrameworkCore;

namespace DesafioAVMB.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}
