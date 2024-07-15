using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class GetDadosUsuarioOutputDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("codigo")]
    public string Codigo { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("iniciais")]
    public string Iniciais { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("ativo")]
    public string Ativo { get; set; }

    [JsonPropertyName("contaVerificada")]
    public string ContaVerificada { get; set; }

    [JsonPropertyName("celular")]
    public string Celular { get; set; }

    [JsonPropertyName("empresa")]
    public string Empresa { get; set; }

    [JsonPropertyName("cargo")]
    public string Cargo { get; set; }

    [JsonPropertyName("imgAssinatura")]
    public string ImgAssinatura { get; set; }

    [JsonPropertyName("imgAssinaturaExt")]
    public string ImgAssinaturaExt { get; set; }

    [JsonPropertyName("imgRubrica")]
    public string ImgRubrica { get; set; }

    [JsonPropertyName("imgRubricaExt")]
    public string ImgRubricaExt { get; set; }

    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("perfilUsuario")]
    public string PerfilUsuario { get; set; }

    [JsonPropertyName("receberLinkAssinatura")]
    public string ReceberLinkAssinatura { get; set; }

    [JsonPropertyName("receberNotifConclusao")]
    public string ReceberNotifConclusao { get; set; }

    [JsonPropertyName("receberNotifPendente")]
    public string ReceberNotifPendente { get; set; }

    [JsonPropertyName("receberNoticias")]
    public string ReceberNoticias { get; set; }

    [JsonPropertyName("utilizaAutenticacao2FA")]
    public string UtilizaAutenticacao2FA { get; set; }

    [JsonPropertyName("imgAutenticacao2FA")]
    public string ImgAutenticacao2FA { get; set; }

    [JsonPropertyName("imgFoto")]
    public string ImgFoto { get; set; }

    [JsonPropertyName("exibeAvisoEnvelope")]
    public string ExibeAvisoEnvelope { get; set; }

    [JsonPropertyName("acessoAPI")]
    public string AcessoAPI { get; set; }

    [JsonPropertyName("tokenAPI")]
    public string TokenAPI { get; set; }

    [JsonPropertyName("urlCallback")]
    public string UrlCallback { get; set; }

    [JsonPropertyName("ignorarPlanoAssin")]
    public string IgnorarPlanoAssin { get; set; }

    [JsonPropertyName("googleAccId")]
    public string GoogleAccId { get; set; }

    [JsonPropertyName("azureAccId")]
    public string AzureAccId { get; set; }

    [JsonPropertyName("ldapAccountName")]
    public string LdapAccountName { get; set; }

    [JsonPropertyName("ordemAssinatura")]
    public string OrdemAssinatura { get; set; }

    [JsonPropertyName("tipoListagemEnvelope")]
    public string TipoListagemEnvelope { get; set; }

    [JsonPropertyName("dataHoraCadastro")]
    public DateTime DataHoraCadastro { get; set; }

    [JsonPropertyName("saldoDisponivelWorkflow")]
    public string SaldoDisponivelWorkflow { get; set; }

    [JsonPropertyName("limiteCards")]
    public string LimiteCards { get; set; }

    [JsonPropertyName("PlanoContratado")]
    public string PlanoContratado { get; set; }

    [JsonPropertyName("limiteEnvelopes")]
    public string LimiteEnvelopes { get; set; }
}
