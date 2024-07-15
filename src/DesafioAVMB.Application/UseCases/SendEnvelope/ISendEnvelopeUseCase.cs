using ErrorOr;

namespace DesafioAVMB.Application.UseCases.SendEnvelope;

public interface ISendEnvelopeUseCase
{
    public Task<ErrorOr<SendEnvelopeUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId);
}
