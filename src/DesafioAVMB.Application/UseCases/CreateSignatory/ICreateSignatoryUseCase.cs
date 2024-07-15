using DesafioAVMB.Domain.Entities;

using ErrorOr;

namespace DesafioAVMB.Application.UseCases.CreateSignatory;

public interface ICreateSignatoryUseCase
{
    public Task<ErrorOr<CreateSignatoryOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId, CreateSignatoryInputDto input);
}
