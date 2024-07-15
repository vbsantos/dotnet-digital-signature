using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Entities;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.SendEnvelope;

public class SendEnvelopeUseCase : ISendEnvelopeUseCase
{
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;
    private readonly IConfiguration _configuration;


    public SendEnvelopeUseCase(
        IEnvelopeRepository envelopeRepository,
        IAstenAssinaturaWebService astenAssinaturaWebService,
        IConfiguration configuration
    )
    {
        _envelopeRepository = envelopeRepository;
        _astenAssinaturaWebService = astenAssinaturaWebService;
        _configuration = configuration;
    }

    public async Task<ErrorOr<SendEnvelopeUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId)
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

            if (envelope is { Sent: true })
            {
                return Error.Conflict("Envelope already sent.");
            }

            envelope.Sent = true;

            // Send the envelope to the signatories
            var encaminharEnvelopeParaAssinaturasInput = new ApiRequest<EncaminharEnvelopeInputDto>()
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new EncaminharEnvelopeInputDto
                {
                    Envelope = new EncaminharEnvelopeInputDtoEnvelope
                    {
                        Id = envelope.ProviderId,
                    },
                    AgendarEnvio = "N",
                    DetectarCampos = "N",
                }
            };
            var apiResponse = await _astenAssinaturaWebService.EncaminharEnvelopeParaAssinaturas(encaminharEnvelopeParaAssinaturasInput);

            await _envelopeRepository.SaveChangesAsync();

            var response = new SendEnvelopeUseCaseOutputDto
            {
                Message = apiResponse.Response.Mensagem,
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
