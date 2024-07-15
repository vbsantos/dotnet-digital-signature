namespace DesafioAVMB.Application.UseCases.CreateEnvelope;

public class CreateEnvelopeOutputDto
{
    public required string Message { get; set; }
    public required Guid EnvelopeId { get; set; }
}
