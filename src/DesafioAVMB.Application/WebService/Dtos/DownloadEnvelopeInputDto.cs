using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class DownloadEnvelopeInputDto
{
    [JsonPropertyName("idEnvelope")]
    public long IdEnvelope { get; set; }
}
