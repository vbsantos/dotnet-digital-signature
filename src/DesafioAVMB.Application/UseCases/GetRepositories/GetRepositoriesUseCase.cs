using DesafioAVMB.Application.Interfaces.Repositories;
using DesafioAVMB.Application.WebService;
using DesafioAVMB.Application.WebService.Dtos;

using ErrorOr;

using Microsoft.Extensions.Configuration;

namespace DesafioAVMB.Application.UseCases.GetRepositories;

public class GetRepositoriesUseCase : IGetRepositoriesUseCase
{
    private readonly IRepositoryRepository _repositoryRepository;
    private readonly IConfiguration _configuration;
    private readonly IAstenAssinaturaWebService _astenAssinaturaWebService;

    public GetRepositoriesUseCase(
        IRepositoryRepository repositoryRepository,
        IConfiguration configuration,
        IAstenAssinaturaWebService astenAssinaturaWebService
    )
    {
        _repositoryRepository = repositoryRepository;
        _configuration = configuration;
        _astenAssinaturaWebService = astenAssinaturaWebService;
    }
    public async Task<ErrorOr<GetRepositoriesUseCaseOutputDto>> Execute(Guid ownerId)
    {
        try
        {
            var repositories = await _repositoryRepository.GetRepositoriesByUserIdAsync(ownerId);

            if (repositories is null || repositories.Count.Equals(0))
            {
                return Error.NotFound("Repositories not found.");
            }

            // Get the digital signature provider user id
            var getIdentificadorInput = new ApiRequest {
                Token = _configuration["DigitalSignatureProvider:Token"]!
            };
            var userData = await _astenAssinaturaWebService.GetIdentificador(getIdentificadorInput);

            // Get User Repositories
            var getRepositoriesInput = new ApiRequest<GetRepositoriosDoUsuarioInputDto>()
            {
                Token = _configuration["DigitalSignatureProvider:Token"]!,
                Params = new GetRepositoriosDoUsuarioInputDto
                {
                    IdProprietario = userData.Response.Usuario.Id
                }
            };
            var apiResponse = await _astenAssinaturaWebService.GetRepositoriosDoUsuario(getRepositoriesInput);

            var response = new GetRepositoriesUseCaseOutputDto
            {
                Repositories = repositories
                    .Select(r => new GetRepositoriesUseCaseOutputDtoRepository {
                        Id = r.Id,
                        Name = apiResponse.Response.First(repo => repo.Id == r.ProviderId).Nome,
                        CreatedAt = apiResponse.Response.First(repo => repo.Id == r.ProviderId).DataHoraCriacao,
                    })
                    .ToList()
            };

            return response;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
