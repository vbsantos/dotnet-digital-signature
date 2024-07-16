using DesafioAVMB.Application.Common;
using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.UseCases.GetEnvelope;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Enums;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.GetEnvelopesByRepositorio;

public class GetEnvelopesByRepositorioUseCase : IGetEnvelopesByRepositorioUseCase
{
    private readonly IRepositoryRepository _repositoryRepository;
    private readonly IConfiguration _configuration;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;

    public GetEnvelopesByRepositorioUseCase(
        IRepositoryRepository repositoryRepository,
        IConfiguration configuration,
        IAstenAssinaturaWebService astenAssinaturaWebService
    )
    {
        _repositoryRepository = repositoryRepository;
        _configuration = configuration;
        _astenAssinaturaWebService = astenAssinaturaWebService;
    }
    public async Task<ErrorOr<GetEnvelopesByRepositorioUseCaseOutputDto>> Execute(Guid ownerId, Guid repositoryId)
    {
        try
        {
            var repository = await _repositoryRepository.GetByIdAsync(repositoryId);

            if (repository is null)
            {
                return Error.NotFound("Repository not found.");
            }

            if (repository.OwnerId != ownerId)
            {
                return Error.Unauthorized("You are not authorized to see this repository.");
            }

            // Get Repository Envelopes
            var getRepositoriesInput = new ApiRequest<GetEnvelopesInputDto>()
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new GetEnvelopesInputDto
                {
                    IdRepositorio = repository.ProviderId,
                }
            };

            try
            {
                var apiResponse = await _astenAssinaturaWebService.GetEnvelopesByRepositorioOuPasta(getRepositoriesInput);
                var response = new GetEnvelopesByRepositorioUseCaseOutputDto
                {
                    Envelopes = apiResponse.Response.Select(x => new GetEnvelopeUseCaseOutputDto
                    {
                        Id = repository.Envelopes.Where(y => y.ProviderId == x.Id).FirstOrDefault()!.Id,
                        Description = x.Descricao,
                        PageCount = x.NumeroPaginas,
                        SignatoryCount = repository.Envelopes.Where(e => e.ProviderId == x.Id).FirstOrDefault()!.SignatoryCount,
                        Status = (EEnvelopeStatus)x.Status,
                        StatusDescription = ParseEnvelopeStatus.Parse((EEnvelopeStatus)x.Status),
                        CreatedAt = x.DataHoraCriacao,
                        UpdatedAt = x.DataHoraAlteracao,
                        Signatories = repository.Envelopes.Where(y => y.ProviderId == x.Id).FirstOrDefault()!.Signatories
                            .Select(x => new GetEnvelopeUseCaseSignatoryDto
                            {
                                Name = x.Name,
                                Email = x.Email,
                            })
                            .ToList(),
                        Documents = repository.Envelopes.Where(y => y.ProviderId == x.Id).FirstOrDefault()!.Documents
                            .Select(x => new GetEnvelopeUseCaseDocumentDto
                            {
                                Name = x.Name,
                            })
                            .ToList(),
                    })
                };
                return response;
            }
            catch (Exception)
            {
                var response = new GetEnvelopesByRepositorioUseCaseOutputDto
                {
                    Envelopes = []
                };
                return response;
            }
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
