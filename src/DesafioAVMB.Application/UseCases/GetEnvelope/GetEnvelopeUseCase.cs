using DesafioAVMB.Application.Common;
using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Enums;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.GetEnvelope;

public class GetEnvelopeUseCase : IGetEnvelopeUseCase
{
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IConfiguration _configuration;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;

    public GetEnvelopeUseCase(
        IEnvelopeRepository envelopeRepository,
        IConfiguration configuration,
        IAstenAssinaturaWebService astenAssinaturaWebService
    )
    {
        _envelopeRepository = envelopeRepository;
        _configuration = configuration;
        _astenAssinaturaWebService = astenAssinaturaWebService;
    }

    public async Task<ErrorOr<GetEnvelopeUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId)
    {
        try
        {
            var envelope = await _envelopeRepository.GetByIdAsync(envelopeId);

            if (envelope is null || envelope.Repository.Id != repositoryId)
            {
                return Error.NotFound("Repositories not found.");
            }

            if (envelope.Repository.OwnerId != ownerId)
            {
                return Error.Unauthorized("You are not authorized to see this envelope.");
            }

            // Get Envelope Data
            var getDadosEnvelopeInputDto = new ApiRequest<GetDadosEnvelopeInputDto>
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new GetDadosEnvelopeInputDto
                {
                    IdEnvelope = envelope.ProviderId,
                    GetLobs = "N"
                }
            };
            var apiReponse = await _astenAssinaturaWebService.GetDadosEnvelope(getDadosEnvelopeInputDto);

            var response = new GetEnvelopeUseCaseOutputDto
            {
                Id = envelope.Id,
                Description = apiReponse.Response.Descricao,
                PageCount = apiReponse.Response.NumeroPaginas,
                Status = (EEnvelopeStatus)apiReponse.Response.Status,
                StatusDescription = ParseEnvelopeStatus.Parse((EEnvelopeStatus)apiReponse.Response.Status),
                CreatedAt = apiReponse.Response.DataHoraCriacao,
                UpdatedAt = apiReponse.Response.DataHoraAlteracao,
                SignatoryCount = envelope.SignatoryCount,
                Signatories = envelope.Signatories
                    .Select(x => new GetEnvelopeUseCaseSignatoryDto
                    {
                        Name = x.Name,
                        Email = x.Email,
                    })
                    .ToList(),
                Documents = envelope.Documents
                    .Select(x => new GetEnvelopeUseCaseDocumentDto
                    {
                        Name = x.Name,
                    })
                    .ToList(),
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
