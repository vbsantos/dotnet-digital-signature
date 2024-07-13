namespace DesafioAVMB.Domain.Entities;

public class Repository
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public required string Name { get; set; }
    public virtual List<Envelope> Envelopes { get; set; } = [];
}
