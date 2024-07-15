namespace DesafioAVMB.Application.WebService.Dtos;

public class GetIdentificadorOutputDto
{
    public GetIdentificadorOutputDtoUsuario Usuario { get; set; } = null!;
}

public class GetIdentificadorOutputDtoUsuario
{
    public long Id { get; set; }
}
