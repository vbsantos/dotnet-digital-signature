using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Entities;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.CreateSignatory;

public class CreateSignatoryUseCase : ICreateSignatoryUseCase
{
    private readonly ISignatoryRepository _signatoryRepository;
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;
    private readonly IConfiguration _configuration;

    public CreateSignatoryUseCase(
        ISignatoryRepository signatoryRepository,
        IEnvelopeRepository envelopeRepository,
        IAstenAssinaturaWebService astenAssinaturaWebService,
        IConfiguration configuration
    )
    {
        _signatoryRepository = signatoryRepository;
        _envelopeRepository = envelopeRepository;
        _astenAssinaturaWebService = astenAssinaturaWebService;
        _configuration = configuration;
    }

    public async Task<ErrorOr<CreateSignatoryOutputDto>> Execute(Guid ownerId, Guid repositoryId, Guid envelopeId, CreateSignatoryInputDto input)
    {
        try
        {
            var envelope = await _envelopeRepository.GetByIdAsync(envelopeId);

            if (envelope is null || envelope.RepositoryId != repositoryId)
            {
                return Error.NotFound("Envelope not found");
            }

            if (envelope.Repository.OwnerId != ownerId)
            {
                return Error.Unauthorized("You are not authorized to add signatories to this envelope");
            }

            var alreadyAddedSignatory = envelope.Signatories.Where(x => x.Email == input.Email).FirstOrDefault();
            if (alreadyAddedSignatory is not null)
            {
                return Error.Conflict("Signatory already added");
            }

            // Increment the number of signatories to keep track of the order
            envelope.SignatoryCount += 1;

            // Add a new signatory to the envelope
            var inserirSignatarioInput = new ApiRequest<InserirSignatarioInputDto>
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new InserirSignatarioInputDto
                {
                    SignatarioEnvelope = new InserirSignatarioInputDtoSignatarioEnvelope
                    {
                        Envelope = new InserirSignatarioInputDtoEnvelope
                        {
                            Id = envelope.ProviderId,
                        },
                        Ordem = envelope.SignatoryCount,
                        ConfigAssinatura = new InserirSignatarioInputDtoConfigAssinatura
                        {
                            EmailSignatario = input.Email,
                            NomeSignatario = input.Name,
                            TipoAssinatura = 1,
                            PermitirDelegar = "N",
                            ApenasCelular = "N",
                            ExigirLogin = "N",
                            ExigirCodigo = "N",
                            ExigirDadosIdentif = "N",
                            AssinaturaPresencial = "N",
                            IgnorarRecusa = "N",
                            IncluirImagensAutentEnvelope = "N",
                            AnalisarFaceImagem = "N",
                            PercentualPrecisaoFace = 0,
                        }
                    }
                }
            };

            var apiResponse = await _astenAssinaturaWebService.InserirSignatarioEnvelope(inserirSignatarioInput);
            var entity = new Signatory
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Email = input.Email,
                Order = envelope.SignatoryCount,
                EnvelopeId = envelopeId,
                ProviderId = apiResponse.Response.Data.IdSignatarioEnv
            };

            await _signatoryRepository.AddAsync(entity);
            await _signatoryRepository.SaveChangesAsync();

            var response = new CreateSignatoryOutputDto
            {
                Message = apiResponse.Response.Mensagem,
                SignatoryId = entity.Id
            };
            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
