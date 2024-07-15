namespace DesafioAVMB.Application.UseCases.GetRepositories;

public class GetRepositoriesUseCaseOutputDto
{
    public required List<GetRepositoriesUseCaseOutputDtoRepository> Repositories { get; set; }
}

public class GetRepositoriesUseCaseOutputDtoRepository
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
}
