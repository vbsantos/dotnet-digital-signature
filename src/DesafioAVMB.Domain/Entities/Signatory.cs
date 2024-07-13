namespace DesafioAVMB.Domain.Entities;

public class Signatory
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required int Order { get; set; }
    public virtual List<Document> Documents { get; set; } = null!;
}
