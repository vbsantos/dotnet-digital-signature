using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetDadosEnvelopeOutputDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("Repositorio")]
    public GetDadosEnvelopeOutputDtoRio Repositorio { get; set; }

    [JsonPropertyName("Usuario")]
    public GetDadosEnvelopeOutputDtoRio Usuario { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }

    [JsonPropertyName("conteudo")]
    public string Conteudo { get; set; }

    [JsonPropertyName("incluirHashTodasPaginas")]
    public string IncluirHashTodasPaginas { get; set; }

    [JsonPropertyName("permitirDespachos")]
    public string PermitirDespachos { get; set; }

    [JsonPropertyName("usarOrdem")]
    public string UsarOrdem { get; set; }

    [JsonPropertyName("hashSHA256")]
    public string HashSha256 { get; set; }

    [JsonPropertyName("hashSHA512")]
    public string HashSha512 { get; set; }

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }

    [JsonPropertyName("mensagemObservadores")]
    public string MensagemObservadores { get; set; }

    [JsonPropertyName("motivoCancelamento")]
    public string MotivoCancelamento { get; set; }

    [JsonPropertyName("numeroPaginas")]
    public long NumeroPaginas { get; set; }

    [JsonPropertyName("status")]
    public long Status { get; set; }

    [JsonPropertyName("dataHoraCriacao")]
    public DateTimeOffset DataHoraCriacao { get; set; }

    [JsonPropertyName("dataHoraAlteracao")]
    public DateTimeOffset DataHoraAlteracao { get; set; }

    [JsonPropertyName("objetoContrato")]
    public string ObjetoContrato { get; set; }

    [JsonPropertyName("statusContrato")]
    public long StatusContrato { get; set; }

    [JsonPropertyName("numContrato")]
    public string NumContrato { get; set; }

    [JsonPropertyName("descricaoContratante")]
    public string DescricaoContratante { get; set; }

    [JsonPropertyName("descricaoContratado")]
    public string DescricaoContratado { get; set; }

    [JsonPropertyName("bloquearDesenhoPaginas")]
    public string BloquearDesenhoPaginas { get; set; }

    [JsonPropertyName("Envelope")]
    public string Envelope { get; set; }
}

public class GetDadosEnvelopeOutputDtoRio
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
