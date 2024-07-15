using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public partial class InserirSignatarioInputDto
{
    [JsonPropertyName("SignatarioEnvelope")]
    public InserirSignatarioInputDtoSignatarioEnvelope SignatarioEnvelope { get; set; }
}

public partial class InserirSignatarioInputDtoSignatarioEnvelope
{
    [JsonPropertyName("Envelope")]
    public InserirSignatarioInputDtoEnvelope Envelope { get; set; }

    [JsonPropertyName("ordem")]
    public long Ordem { get; set; }

    [JsonPropertyName("tagAncoraCampos")]
    public object TagAncoraCampos { get; set; }

    [JsonPropertyName("ConfigAssinatura")]
    public InserirSignatarioInputDtoConfigAssinatura ConfigAssinatura { get; set; }
}

public partial class InserirSignatarioInputDtoConfigAssinatura
{
    [JsonPropertyName("emailSignatario")]
    public string EmailSignatario { get; set; }

    [JsonPropertyName("nomeSignatario")]
    public string NomeSignatario { get; set; }

    [JsonPropertyName("celularSignatario")]
    public object CelularSignatario { get; set; }

    [JsonPropertyName("opcaoAutenticacao")]
    public object OpcaoAutenticacao { get; set; }

    [JsonPropertyName("tipoAssinatura")]
    public long TipoAssinatura { get; set; }

    [JsonPropertyName("permitirDelegar")]
    public string PermitirDelegar { get; set; }

    [JsonPropertyName("apenasCelular")]
    public string ApenasCelular { get; set; }

    [JsonPropertyName("exigirLogin")]
    public string ExigirLogin { get; set; }

    [JsonPropertyName("exigirCodigo")]
    public string ExigirCodigo { get; set; }

    [JsonPropertyName("exigirDadosIdentif")]
    public string ExigirDadosIdentif { get; set; }

    [JsonPropertyName("assinaturaPresencial")]
    public string AssinaturaPresencial { get; set; }

    [JsonPropertyName("nomeSignPresencial")]
    public object NomeSignPresencial { get; set; }

    [JsonPropertyName("cpfSignPresencial")]
    public object CpfSignPresencial { get; set; }

    [JsonPropertyName("ignorarRecusa")]
    public string IgnorarRecusa { get; set; }

    [JsonPropertyName("codigoExigido")]
    public object CodigoExigido { get; set; }

    [JsonPropertyName("incluirImagensAutentEnvelope")]
    public string IncluirImagensAutentEnvelope { get; set; }

    [JsonPropertyName("analisarFaceImagem")]
    public string AnalisarFaceImagem { get; set; }

    [JsonPropertyName("percentualPrecisaoFace")]
    public long PercentualPrecisaoFace { get; set; }

    [JsonPropertyName("intervaloPaginaDesenho")]
    public string IntervaloPaginaDesenho { get; set; }
}

public partial class InserirSignatarioInputDtoEnvelope
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
