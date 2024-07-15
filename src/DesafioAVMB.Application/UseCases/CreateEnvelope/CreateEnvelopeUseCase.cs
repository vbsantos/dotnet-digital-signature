using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Entities;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.CreateEnvelope;

public class CreateEnvelopeUseCase : ICreateEnvelopeUseCase
{
    private readonly IRepositoryRepository _repositoryRepository;
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;
    private readonly IConfiguration _configuration;

    public CreateEnvelopeUseCase(
        IEnvelopeRepository envelopeRepository,
        IDocumentRepository documentRepository,
        IRepositoryRepository repositoryRepository,
        IAstenAssinaturaWebService astenAssinaturaWebService,
        IConfiguration configuration
    )
    {
        _envelopeRepository = envelopeRepository;
        _documentRepository = documentRepository;
        _repositoryRepository = repositoryRepository;
        _astenAssinaturaWebService = astenAssinaturaWebService;
        _configuration = configuration;
    }

    public async Task<ErrorOr<CreateEnvelopeOutputDto>> Execute(Guid ownerId, Guid repositoryId, CreateEnvelopeInputDto input)
    {
        try
        {
            var repository = await _repositoryRepository.GetByIdAsync(repositoryId);

            if (repository is null)
            {
                return Error.NotFound("Repository not found");
            }

            if (repository.OwnerId != ownerId)
            {
                return Error.Unauthorized("You are not authorized to create envelopes in this repository");
            }

            if (input.Documents.Count == 0)
            {
                return Error.Validation("Envelope must have at least one document");
            }

            // Create the envelope at the provider
            var inserirEnvelopeInput = new ApiRequest<InserirEnvelopeInputDto>
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new InserirEnvelopeInputDto
                {
                    Envelope = new InserirEnvelopeInputDtoEnvelope
                    {
                        Descricao = input.Description,
                        Repositorio = new InserirEnvelopeInputDtoRepositorio
                        {
                            Id = repository.ProviderId,
                        },
                        ListaDocumentos = new InserirEnvelopeInputDtoListaDocumentos() {
                            Documento = input.Documents
                                .Select(x => new InserirEnvelopeInputDtoDocumento {
                                    NomeArquivo = x.Name,
                                    MimeType = x.MimeType,
                                    Conteudo = x.Base64Content
                                })
                                .ToList()
                        },
                        IncluirHashTodasPaginas = "S",
                        PermitirDespachos = "S",
                        IgnorarNotificacoes = "N",
                        IgnorarNotificacoesPendentes = "N",
                        BloquearDesenhoPaginas = "S",
                    },
                    GerarTags = "S",
                    EncaminharImediatamente = "N",
                    DetectarCampos = "N",
                    VerificarDuplicidadeConteudo = "N",
                    ProcessarImagensEmSegundoPlano = "N",
                }
            };
            var apiResponse = await _astenAssinaturaWebService.InserirEnvelope(inserirEnvelopeInput);

            var envelopeId = Guid.NewGuid();
            var entity = new Envelope
            {
                Id = envelopeId,
                ProviderId = apiResponse.Response.Data.IdEnvelope,
                RepositoryId = repositoryId,
                Description = input.Description,
            };

            await _envelopeRepository.AddAsync(entity);

            foreach (var document in input.Documents)
            {
                await _documentRepository.AddAsync(new Document
                {
                    Id = Guid.NewGuid(),
                    EnvelopeId = envelopeId,
                    Name = document.Name,
                    MimeType = document.MimeType,
                    Base64Content = document.Base64Content
                });
            }

            await _documentRepository.SaveChangesAsync();

            var response = new CreateEnvelopeOutputDto
            {
                EnvelopeId = envelopeId,
                Message = apiResponse.Response.Mensagem
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
