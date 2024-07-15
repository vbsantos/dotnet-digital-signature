using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.GetFile;

public class GetFileUseCase : IGetFileUseCase
{
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;
    private readonly IConfiguration _configuration;


    public GetFileUseCase(
        IEnvelopeRepository envelopeRepository,
        IAstenAssinaturaWebService astenAssinaturaWebService,
        IConfiguration configuration
    )
    {
        _envelopeRepository = envelopeRepository;
        _astenAssinaturaWebService = astenAssinaturaWebService;
        _configuration = configuration;
    }

    public async Task<ErrorOr<GetFileUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId)
    {
        try
        {
            var envelope = await _envelopeRepository.GetByIdAsync(envelopeId);

            if (envelope is null || envelope.RepositoryId != repositoryId)
            {
                return Error.NotFound("Envelope not found.");
            }

            if (envelope.Repository.OwnerId != ownerId)
            {
                return Error.Unauthorized("You are not authorized to send this envelope.");
            }

            // Download the envelope
            var downloadEnvelopeInput = new ApiRequest<DownloadEnvelopeInputDto>
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new DownloadEnvelopeInputDto
                {
                    IdEnvelope = envelope.ProviderId,
                }
            };
            var apiResponse = await _astenAssinaturaWebService.DownloadEnvelope(downloadEnvelopeInput);

            await _envelopeRepository.SaveChangesAsync();

            var response = new GetFileUseCaseOutputDto
            {
                Name = apiResponse.Response.NomeArquivo,
                Content = apiResponse.Response.EnvelopeContent,
                MimeType = apiResponse.Response.MimeType
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
