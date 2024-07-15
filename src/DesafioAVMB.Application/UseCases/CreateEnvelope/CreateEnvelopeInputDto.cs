namespace DesafioAVMB.Application.UseCases.CreateEnvelope;

public class CreateEnvelopeInputDto
{
    public required string Description { get; set; }
    public required List<DocumentDto> Documents { get; set; } = [];
}
