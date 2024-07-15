namespace DesafioAVMB.Domain.Entities;

public class Signatory
{
    public Guid Id { get; set; }
    public required Guid EnvelopeId { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required int Order { get; set; }
    public virtual Envelope Envelope { get; set; } = null!;
    public long ProviderId { get; set; }
}
