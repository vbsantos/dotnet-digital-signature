using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public partial class InserirSignatarioOutputDto
{
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }

    [JsonPropertyName("data")]
    public InserirSignatarioOutputDtoData Data { get; set; }
}

public partial class InserirSignatarioOutputDtoData
{
    [JsonPropertyName("idSignatarioEnv")]
    public long IdSignatarioEnv { get; set; }

    [JsonPropertyName("listaAvisos")]
    public InserirSignatarioOutputDtoListaAvisos ListaAvisos { get; set; }
}

public partial class InserirSignatarioOutputDtoListaAvisos
{
    [JsonPropertyName("aviso")]
    public InserirSignatarioOutputDtoAviso Aviso { get; set; }
}

public partial class InserirSignatarioOutputDtoAviso
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; }

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }
}
