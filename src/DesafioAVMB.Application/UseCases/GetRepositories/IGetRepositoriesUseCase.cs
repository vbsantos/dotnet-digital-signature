using ErrorOr;

namespace DesafioAVMB.Application.UseCases.GetRepositories;

public interface IGetRepositoriesUseCase
{
    public Task<ErrorOr<GetRepositoriesUseCaseOutputDto>> Execute(Guid ownerId);
}
