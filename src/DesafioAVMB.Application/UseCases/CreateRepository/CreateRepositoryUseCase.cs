using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;
using DesafioAVMB.Domain.Entities;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.CreateRepository;

public class CreateRepositoryUseCase : ICreateRepositoryUseCase
{
    private readonly IRepositoryRepository _repositoryRepository;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;
    private readonly IConfiguration _configuration;

    public CreateRepositoryUseCase(
        IRepositoryRepository repositoryRepository,
        IAstenAssinaturaWebService astenAssinaturaWebService,
        IConfiguration configuration
    )
    {
        _repositoryRepository = repositoryRepository;
        _astenAssinaturaWebService = astenAssinaturaWebService;
        _configuration = configuration;
    }

    public async Task<ErrorOr<CreateRepositoryOutputDto>> Execute(Guid userId, CreateRepositoryInputDto input)
    {
        try
        {
            // Get the digital signature provider user id
            var getIdentificadorInput = new ApiRequest {
                Token = _configuration["DigitalSignatureProvider:Token"]!
            };
            var userData = await _astenAssinaturaWebService.GetIdentificador(getIdentificadorInput);

            // Create the repository at the provider
            var InserirRepositorioInput = new ApiRequest<InserirRepositorioInputDto> {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new InserirRepositorioInputDto {
                    Repositorio = new InserirRepositorioInputDtoRepositorio {
                        Usuario = new InserirRepositorioInputDtoUsuario {
                            Id = userData.Response.Usuario.Id
                        },
                        Nome = input.Name,
                        CompartilharCriacaoDocs = "S",
                        CompartilharVisualizacaoDocs = "S",
                        OcultarEmailSignatarios = "N",
                        OpcaoValidCodigo = "S",
                        OpcaoValidCertIcp = "S",
                        OpcaoValidDocFoto = "S",
                        OpcaoValidDocSelfie = "S",
                        OpcaoValidTokenSms = "S",
                        OpcaoValidLogin = "S",
                        OpcaoValidReconhecFacial = "S",
                        OpcaoValidPix = "S",
                        LembrarAssinPendentes = "S"
                    }
                }
            };
            var apiResponse = await _astenAssinaturaWebService.InserirRepositorio(InserirRepositorioInput);

            var entity = new Repository
            {
                Id = Guid.NewGuid(),
                ProviderId = apiResponse.Response.Data.IdRepositorio,
                OwnerId = userId,
                OwnerProviderId = userData.Response.Usuario.Id,
                Name = input.Name,
            };

            await _repositoryRepository.AddAsync(entity);

            await _repositoryRepository.SaveChangesAsync();

            var response = new CreateRepositoryOutputDto
            {
                Message = apiResponse.Response.Mensagem,
                RepositoryId = entity.Id
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
