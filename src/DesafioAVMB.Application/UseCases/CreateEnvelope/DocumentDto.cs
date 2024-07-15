namespace DesafioAVMB.Application.UseCases.CreateEnvelope;

public class DocumentDto
{
    public required string Name { get; set; }
    public required string MimeType { get; set; }
    public required string Base64Content { get; set; }
}
