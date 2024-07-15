using DesafioAVMB.Application.WebService.Dtos;

namespace DesafioAVMB.Application.WebService;

public interface IAstenAssinaturaWebService
{
    public Task<ApiResponse<GetIdentificadorOutputDto>> GetIdentificador(ApiRequest requestBody);
    public Task<ApiResponse<GetDadosUsuarioOutputDto>> GetDadosUsuario(ApiRequest<GetDadosUsuarioInputDto> requestBody);
    public Task<ApiResponse<InserirRepositorioOutputDto>> InserirRepositorio(ApiRequest<InserirRepositorioInputDto> requestBody);
    public Task<ApiResponse<InserirEnvelopeOutputDto>> InserirEnvelope(ApiRequest<InserirEnvelopeInputDto> requestBody);
    public Task<ApiResponse<InserirSignatarioOutputDto>> InserirSignatarioEnvelope(ApiRequest<InserirSignatarioInputDto> requestBody);
    public Task<ApiResponse<EncaminharEnvelopeOutputDto>> EncaminharEnvelopeParaAssinaturas(ApiRequest<EncaminharEnvelopeInputDto> requestBody);
    public Task<ApiResponse<DownloadEnvelopeOutputDto>> DownloadEnvelope(ApiRequest<DownloadEnvelopeInputDto> requestBody);
    public Task<ApiResponse<IEnumerable<GetRepositoriosDoUsuarioOutputDto>>> GetRepositoriosDoUsuario(ApiRequest<GetRepositoriosDoUsuarioInputDto> requestBody);
    public Task<ApiResponse<GetDadosEnvelopeOutputDto>> GetDadosEnvelope(ApiRequest<GetDadosEnvelopeInputDto> requestBody);
}
