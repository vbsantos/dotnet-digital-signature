namespace DesafioAVMB.Application.UseCases.GetFile;

public class GetFileUseCaseOutputDto
{
    public required string Name { get; set; }
    public required string Content { get; set; }
    public required string MimeType { get; set; }
}
