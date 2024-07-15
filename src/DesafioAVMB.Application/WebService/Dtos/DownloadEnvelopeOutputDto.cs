using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class DownloadEnvelopeOutputDto
{
    [JsonPropertyName("envelopeContent")]
    public string EnvelopeContent { get; set; }

    [JsonPropertyName("nomeArquivo")]
    public string NomeArquivo { get; set; }

    [JsonPropertyName("mimeType")]
    public string MimeType { get; set; }
}
