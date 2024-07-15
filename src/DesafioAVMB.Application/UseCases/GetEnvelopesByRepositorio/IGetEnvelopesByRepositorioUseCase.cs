using ErrorOr;

namespace DesafioAVMB.Application.UseCases.GetEnvelopesByRepositorio;

public interface IGetEnvelopesByRepositorioUseCase
{
    public Task<ErrorOr<GetEnvelopesByRepositorioUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId);
}
