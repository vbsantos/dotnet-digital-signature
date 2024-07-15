using ErrorOr;

namespace DesafioAVMB.Application.UseCases.CreateRepository;

public interface ICreateRepositoryUseCase
{
    public Task<ErrorOr<CreateRepositoryOutputDto>> Execute(Guid userId, CreateRepositoryInputDto input);
}
