using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetDadosEnvelopeInputDto
{
    [JsonPropertyName("idEnvelope")]
    public long IdEnvelope { get; set; }

    [JsonPropertyName("getLobs")]
    public string GetLobs { get; set; }
}
