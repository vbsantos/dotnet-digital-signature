namespace DesafioAVMB.Application.WebService.Dtos;

public class ApiRequest<TParams>
{
    public string Token { get; set; } = null!;
    public TParams Params { get; set; } = default!;
}

public class ApiRequest
{
    public string Token { get; set; } = null!;
    public Object Params { get; set; } = null!;
}
