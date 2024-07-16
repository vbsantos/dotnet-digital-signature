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
    public int SignatoryCount { get; set; }
    public List<GetEnvelopeUseCaseSignatoryDto> Signatories { get; set; } = null!;
    public List<GetEnvelopeUseCaseDocumentDto> Documents { get; set; } = null!;
}

public class GetEnvelopeUseCaseSignatoryDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}

public class GetEnvelopeUseCaseDocumentDto
{
    public required string Name { get; set; }
}
