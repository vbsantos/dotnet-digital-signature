namespace DesafioAVMB.Domain.Entities;

public class Envelope
{
    public Guid Id { get; set; }
    public Guid RepositoryId { get; set; }
    public string Description { get; set; } = "";
    public virtual List<Document> Documents { get; set; } = [];
    public virtual Repository Repository { get; set; } = null!;
}
