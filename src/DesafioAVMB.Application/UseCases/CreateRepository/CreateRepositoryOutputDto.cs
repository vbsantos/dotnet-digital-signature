namespace DesafioAVMB.Application.UseCases.CreateRepository;

public class CreateRepositoryOutputDto
{
    public required string Message { get; set; }
    public required Guid RepositoryId { get; set; }
}
