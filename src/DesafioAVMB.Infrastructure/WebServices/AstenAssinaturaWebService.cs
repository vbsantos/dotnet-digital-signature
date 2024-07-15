using System.Net.Http.Json;

using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Infrastructure.WebServices;

public class AstenAssinaturaWebService : IAstenAssinaturaWebService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AstenAssinaturaWebService(
        HttpClient httpClient,
        IConfiguration configuration
    )
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ApiResponse<GetIdentificadorOutputDto>> GetIdentificador(ApiRequest requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/getIdentificador", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<GetIdentificadorOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<GetDadosUsuarioOutputDto>> GetDadosUsuario(ApiRequest<GetDadosUsuarioInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/getDadosUsuario", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<GetDadosUsuarioOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<InserirRepositorioOutputDto>> InserirRepositorio(ApiRequest<InserirRepositorioInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/inserirRepositorio", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<InserirRepositorioOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<InserirEnvelopeOutputDto>> InserirEnvelope(ApiRequest<InserirEnvelopeInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/inserirEnvelope", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<InserirEnvelopeOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<InserirSignatarioOutputDto>> InserirSignatarioEnvelope(ApiRequest<InserirSignatarioInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/inserirSignatarioEnvelope", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<InserirSignatarioOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<EncaminharEnvelopeOutputDto>> EncaminharEnvelopeParaAssinaturas(ApiRequest<EncaminharEnvelopeInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/encaminharEnvelopeParaAssinaturas", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<EncaminharEnvelopeOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<DownloadEnvelopeOutputDto>> DownloadEnvelope(ApiRequest<DownloadEnvelopeInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/downloadEnvelopePades", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<DownloadEnvelopeOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<IEnumerable<GetRepositoriosDoUsuarioOutputDto>>> GetRepositoriosDoUsuario(ApiRequest<GetRepositoriosDoUsuarioInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/getRepositoriosDoUsuario", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<GetRepositoriosDoUsuarioOutputDto>>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<GetDadosEnvelopeOutputDto>> GetDadosEnvelope(ApiRequest<GetDadosEnvelopeInputDto> requestBody)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync($"{_configuration["DigitalSignatureProvider:BaseUrlApi"]}/getDadosEnvelope", requestBody);
        httpResponse.EnsureSuccessStatusCode();

        var apiResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<GetDadosEnvelopeOutputDto>>();
        if (httpResponse is null || apiResponse is null)
        {
            throw new HttpRequestException("No response from API.");
        }

        return apiResponse;
    }
}
