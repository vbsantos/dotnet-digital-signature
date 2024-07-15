using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetRepositoriosDoUsuarioOutputDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("Usuario")]
    public GetRepositoriosDoUsuarioOutputDtoUsuario Usuario { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("compartilharCriacaoDocs")]
    public string CompartilharCriacaoDocs { get; set; }

    [JsonPropertyName("compartilharVisualizacaoDocs")]
    public string CompartilharVisualizacaoDocs { get; set; }

    [JsonPropertyName("ocultarEmailSignatarios")]
    public string OcultarEmailSignatarios { get; set; }

    [JsonPropertyName("nomeRemetente")]
    public string NomeRemetente { get; set; }

    [JsonPropertyName("opcaoValidCodigo")]
    public string OpcaoValidCodigo { get; set; }

    [JsonPropertyName("opcaoValidCertICP")]
    public string OpcaoValidCertIcp { get; set; }

    [JsonPropertyName("opcaoValidDocFoto")]
    public string OpcaoValidDocFoto { get; set; }

    [JsonPropertyName("opcaoValidDocSelfie")]
    public string OpcaoValidDocSelfie { get; set; }

    [JsonPropertyName("opcaoValidTokenSMS")]
    public string OpcaoValidTokenSms { get; set; }

    [JsonPropertyName("opcaoValidLogin")]
    public string OpcaoValidLogin { get; set; }

    [JsonPropertyName("opcaoValidReconhecFacial")]
    public string OpcaoValidReconhecFacial { get; set; }

    [JsonPropertyName("opcaoValidPix")]
    public string OpcaoValidPix { get; set; }

    [JsonPropertyName("lembrarAssinPendentes")]
    public string LembrarAssinPendentes { get; set; }

    [JsonPropertyName("dataHoraCriacao")]
    public DateTimeOffset DataHoraCriacao { get; set; }

    [JsonPropertyName("isProprietario")]
    public string IsProprietario { get; set; }
}

public class GetRepositoriosDoUsuarioOutputDtoUsuario
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
