using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class InserirEnvelopeInputDto
{
    [JsonPropertyName("Envelope")]
    public InserirEnvelopeInputDtoEnvelope Envelope { get; set; }

    [JsonPropertyName("gerarTags")]
    public string GerarTags { get; set; }

    [JsonPropertyName("encaminharImediatamente")]
    public string EncaminharImediatamente { get; set; }

    [JsonPropertyName("detectarCampos")]
    public string DetectarCampos { get; set; }

    [JsonPropertyName("verificarDuplicidadeConteudo")]
    public string VerificarDuplicidadeConteudo { get; set; }

    [JsonPropertyName("processarImagensEmSegundoPlano")]
    public string ProcessarImagensEmSegundoPlano { get; set; }
}

public class InserirEnvelopeInputDtoEnvelope
{
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }

    [JsonPropertyName("Repositorio")]
    public InserirEnvelopeInputDtoRepositorio Repositorio { get; set; }

    [JsonPropertyName("mensagem")]
    public object Mensagem { get; set; }

    [JsonPropertyName("mensagemObservadores")]
    public object MensagemObservadores { get; set; }

    [JsonPropertyName("mensagemNotificacaoSMS")]
    public object MensagemNotificacaoSms { get; set; }

    [JsonPropertyName("dataExpiracao")]
    public object DataExpiracao { get; set; }

    [JsonPropertyName("horaExpiracao")]
    public object HoraExpiracao { get; set; }

    [JsonPropertyName("usarOrdem")]
    public string UsarOrdem { get; set; }

    [JsonPropertyName("ConfigAuxiliar")]
    public InserirEnvelopeInputDtoConfigAuxiliar ConfigAuxiliar { get; set; }

    [JsonPropertyName("listaDocumentos")]
    public InserirEnvelopeInputDtoListaDocumentos ListaDocumentos { get; set; }

    [JsonPropertyName("listaSignatariosEnvelope")]
    public InserirEnvelopeInputDtoListaSignatariosEnvelope ListaSignatariosEnvelope { get; set; }

    [JsonPropertyName("listaObservadores")]
    public InserirEnvelopeInputDtoListaObservadores ListaObservadores { get; set; }

    [JsonPropertyName("listaTags")]
    public InserirEnvelopeInputDtoListaTags ListaTags { get; set; }

    [JsonPropertyName("listaInfoAdicional")]
    public InserirEnvelopeInputDtoListaInfoAdicional ListaInfoAdicional { get; set; }

    [JsonPropertyName("incluirHashTodasPaginas")]
    public string IncluirHashTodasPaginas { get; set; }

    [JsonPropertyName("permitirDespachos")]
    public string PermitirDespachos { get; set; }

    [JsonPropertyName("ignorarNotificacoes")]
    public string IgnorarNotificacoes { get; set; }

    [JsonPropertyName("ignorarNotificacoesPendentes")]
    public string IgnorarNotificacoesPendentes { get; set; }

    [JsonPropertyName("qrCodePosLeft")]
    public object QrCodePosLeft { get; set; }

    [JsonPropertyName("qrCodePosTop")]
    public object QrCodePosTop { get; set; }

    [JsonPropertyName("dataIniContrato")]
    public object DataIniContrato { get; set; }

    [JsonPropertyName("dataFimContrato")]
    public object DataFimContrato { get; set; }

    [JsonPropertyName("objetoContrato")]
    public object ObjetoContrato { get; set; }

    [JsonPropertyName("numContrato")]
    public object NumContrato { get; set; }

    [JsonPropertyName("valorContrato")]
    public object ValorContrato { get; set; }

    [JsonPropertyName("descricaoContratante")]
    public object DescricaoContratante { get; set; }

    [JsonPropertyName("descricaoContratado")]
    public object DescricaoContratado { get; set; }

    [JsonPropertyName("bloquearDesenhoPaginas")]
    public string BloquearDesenhoPaginas { get; set; }
}

public class InserirEnvelopeInputDtoConfigAuxiliar
{
    [JsonPropertyName("documentosComXMLs")]
    public string DocumentosComXmLs { get; set; }

    [JsonPropertyName("urlCarimboTempo")]
    public object UrlCarimboTempo { get; set; }
}

public class InserirEnvelopeInputDtoListaDocumentos
{
    [JsonPropertyName("Documento")]
    public List<InserirEnvelopeInputDtoDocumento> Documento { get; set; }
}

public class InserirEnvelopeInputDtoDocumento
{
    [JsonPropertyName("nomeArquivo")]
    public string NomeArquivo { get; set; }

    [JsonPropertyName("mimeType")]
    public string MimeType { get; set; }

    [JsonPropertyName("conteudo")]
    public string Conteudo { get; set; }
}

public class InserirEnvelopeInputDtoListaInfoAdicional
{
    [JsonPropertyName("InfoAdicional")]
    public object[] InfoAdicional { get; set; }
}

public class InserirEnvelopeInputDtoListaObservadores
{
    [JsonPropertyName("Observador")]
    public object[] Observador { get; set; }
}

public class InserirEnvelopeInputDtoListaSignatariosEnvelope
{
    [JsonPropertyName("SignatarioEnvelope")]
    public object[] SignatarioEnvelope { get; set; }
}

public class InserirEnvelopeInputDtoListaTags
{
    [JsonPropertyName("Tag")]
    public object[] Tag { get; set; }
}

public class InserirEnvelopeInputDtoRepositorio
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}
