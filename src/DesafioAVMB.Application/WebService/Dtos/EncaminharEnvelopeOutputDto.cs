using System.Text.Json.Serialization;

namespace DesafioAVMB.Application.WebService.Dtos;

public class EncaminharEnvelopeOutputDto
{
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }

    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonPropertyName("xmlns")]
    public Uri Xmlns { get; set; }

    [JsonPropertyName("listaAvisos")]
    public ListaAvisos ListaAvisos { get; set; }
}

public class ListaAvisos
{
    [JsonPropertyName("aviso")]
    public Aviso Aviso { get; set; }
}

public class Aviso
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; }

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }
}
