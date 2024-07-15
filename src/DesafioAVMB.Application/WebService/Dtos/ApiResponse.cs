namespace DesafioAVMB.Application.WebService.Dtos;

public class ApiResponse<TReponse>
{
    public TReponse Response { get; set; } = default!;
}
