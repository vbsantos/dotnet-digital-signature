namespace DesafioAVMB.Application.UseCases.CreateSignatory;

public class CreateSignatoryOutputDto
{
    public required string Message { get; set; }
    public Guid? SignatoryId { get; set; }
}
