using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class InserirEnvelopeOutputDto
{
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }

    [JsonPropertyName("data")]
    public InserirEnvelopeOutputDtoData Data { get; set; }
}

public class InserirEnvelopeOutputDtoData
{
    [JsonPropertyName("listaAvisos")]
    public InserirEnvelopeOutputDtoListaAvisos ListaAvisos { get; set; }

    [JsonPropertyName("idEnvelope")]
    public long IdEnvelope { get; set; }

    [JsonPropertyName("hashSHA256")]
    public string HashSha256 { get; set; }
}

public class InserirEnvelopeOutputDtoListaAvisos
{
    [JsonPropertyName("aviso")]
    public InserirEnvelopeOutputDtoAviso Aviso { get; set; }
}

public class InserirEnvelopeOutputDtoAviso
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; }

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }
}
