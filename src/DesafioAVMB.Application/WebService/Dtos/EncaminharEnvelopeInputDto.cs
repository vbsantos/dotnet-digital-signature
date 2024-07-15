using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class EncaminharEnvelopeInputDto
{
    [JsonPropertyName("Envelope")]
    public EncaminharEnvelopeInputDtoEnvelope Envelope { get; set; }

    [JsonPropertyName("agendarEnvio")]
    public string AgendarEnvio { get; set; }

    [JsonPropertyName("detectarCampos")]
    public string DetectarCampos { get; set; }

    [JsonPropertyName("dataEnvioAgendado")]
    public object DataEnvioAgendado { get; set; }

    [JsonPropertyName("horaEnvioAgendado")]
    public object HoraEnvioAgendado { get; set; }
}

public class EncaminharEnvelopeInputDtoEnvelope
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
