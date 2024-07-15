using ErrorOr;

namespace DesafioAVMB.Application.UseCases.GetFile;

public interface IGetFileUseCase
{
    public Task<ErrorOr<GetFileUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId);
}
