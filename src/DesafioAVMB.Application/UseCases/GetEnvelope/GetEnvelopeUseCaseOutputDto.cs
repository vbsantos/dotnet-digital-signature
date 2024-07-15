using DesafioAVMB.Domain.Enums;

namespace DesafioAVMB.Application.UseCases.GetEnvelope;

public class GetEnvelopeUseCaseOutputDto
{
    public required Guid Id { get; set; }
    public required string Description { get; set; }
    public long PageCount { get; set; }
    public EEnvelopeStatus Status { get; set; }
    public required string StatusDescription { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
