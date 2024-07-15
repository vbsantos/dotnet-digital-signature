using ErrorOr;

namespace DesafioAVMB.Application.UseCases.GetEnvelope;

public interface IGetEnvelopeUseCase
{
    public Task<ErrorOr<GetEnvelopeUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId);
}
