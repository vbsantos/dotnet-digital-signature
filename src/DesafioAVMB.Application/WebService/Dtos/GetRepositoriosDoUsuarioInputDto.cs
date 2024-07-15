using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetRepositoriosDoUsuarioInputDto
{
    [JsonPropertyName("idProprietario")]
    public long IdProprietario { get; set; }
}
