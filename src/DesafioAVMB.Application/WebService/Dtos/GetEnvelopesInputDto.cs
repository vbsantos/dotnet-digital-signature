using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetEnvelopesInputDto
{
    [JsonPropertyName("idRepositorio")]
    public long IdRepositorio { get; set; }
}
