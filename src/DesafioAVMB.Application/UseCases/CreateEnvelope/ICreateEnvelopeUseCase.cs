using ErrorOr;

namespace DesafioAVMB.Application.UseCases.CreateEnvelope;

public interface ICreateEnvelopeUseCase
{
    public Task<ErrorOr<CreateEnvelopeOutputDto>> Execute(Guid ownerId, Guid repositoryId, CreateEnvelopeInputDto input);
}
