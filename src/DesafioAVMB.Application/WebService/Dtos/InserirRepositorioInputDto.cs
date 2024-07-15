using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class InserirRepositorioInputDto
{
    [JsonPropertyName("Repositorio")]
    public InserirRepositorioInputDtoRepositorio Repositorio { get; set; }
}

public class InserirRepositorioInputDtoRepositorio
{
    [JsonPropertyName("Usuario")]
    public InserirRepositorioInputDtoUsuario Usuario { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("compartilharCriacaoDocs")]
    public string CompartilharCriacaoDocs { get; set; }

    [JsonPropertyName("compartilharVisualizacaoDocs")]
    public string CompartilharVisualizacaoDocs { get; set; }

    [JsonPropertyName("ocultarEmailSignatarios")]
    public string OcultarEmailSignatarios { get; set; }

    [JsonPropertyName("nomeRemetente")]
    public object NomeRemetente { get; set; }

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
}

public class InserirRepositorioInputDtoUsuario
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
