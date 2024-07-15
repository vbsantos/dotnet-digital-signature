using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public partial class InserirRepositorioOutputDto
{
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }

    [JsonPropertyName("data")]
    public InserirRepositorioOutputDtoData Data { get; set; }
}

public partial class InserirRepositorioOutputDtoData
{
    [JsonPropertyName("idRepositorio")]
    public long IdRepositorio { get; set; }

    [JsonPropertyName("listaAvisos")]
    public InserirRepositorioOutputDtoListaAvisos ListaAvisos { get; set; }
}

public partial class InserirRepositorioOutputDtoListaAvisos
{
    [JsonPropertyName("aviso")]
    public InserirRepositorioOutputDtoAviso Aviso { get; set; }
}

public partial class InserirRepositorioOutputDtoAviso
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; }

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }
}
