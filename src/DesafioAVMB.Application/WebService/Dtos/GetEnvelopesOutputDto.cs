using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetEnvelopesOutputDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }

    [JsonPropertyName("dataHoraCriacao")]
    public DateTimeOffset DataHoraCriacao { get; set; }

    [JsonPropertyName("dataHoraAlteracao")]
    public DateTimeOffset DataHoraAlteracao { get; set; }

    [JsonPropertyName("status")]
    public long Status { get; set; }

    [JsonPropertyName("numeroPaginas")]
    public long NumeroPaginas { get; set; }

    [JsonPropertyName("hashSHA256")]
    public string HashSha256 { get; set; }

    [JsonPropertyName("permitirDownload")]
    public string PermitirDownload { get; set; }

    [JsonPropertyName("permitirResetarExpiracao")]
    public string PermitirResetarExpiracao { get; set; }

    [JsonPropertyName("permitirAlterarExpiracao")]
    public string PermitirAlterarExpiracao { get; set; }

    [JsonPropertyName("permitirRestaurarDaLixeira")]
    public string PermitirRestaurarDaLixeira { get; set; }

    [JsonPropertyName("permitirEnvioParaLixeira")]
    public string PermitirEnvioParaLixeira { get; set; }

    [JsonPropertyName("permitirDespachos")]
    public string PermitirDespachos { get; set; }

    [JsonPropertyName("emAcompanhamento")]
    public string EmAcompanhamento { get; set; }

    [JsonPropertyName("tipoOrigem")]
    public long TipoOrigem { get; set; }

    [JsonPropertyName("Usuario")]
    public GetEnvelopesOutputDtoUsuario Usuario { get; set; }

    [JsonPropertyName("statusContrato")]
    public long StatusContrato { get; set; }

    [JsonPropertyName("numContrato")]
    public string NumContrato { get; set; }

    [JsonPropertyName("listaTags")]
    public GetEnvelopesOutputDtoListaTags ListaTags { get; set; }

    [JsonPropertyName("permiteArquivar")]
    public string PermiteArquivar { get; set; }

    [JsonPropertyName("permiteCancelar")]
    public string PermiteCancelar { get; set; }

    [JsonPropertyName("statusColor")]
    public string StatusColor { get; set; }
}

public class GetEnvelopesOutputDtoListaTags
{
    [JsonPropertyName("Tag")]
    public GetEnvelopesOutputDtoTag[] Tag { get; set; }
}

public class GetEnvelopesOutputDtoTag
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }
}

public class GetEnvelopesOutputDtoUsuario
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }
}
