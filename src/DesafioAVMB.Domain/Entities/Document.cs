namespace DesafioAVMB.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public Guid EnvelopeId { get; set; }
    public required string Name { get; set; }
    public required string MimeType { get; set; }
    public required string Base64Content { get; set; }
    public virtual Envelope Envelope { get; set; } = null!;
}
