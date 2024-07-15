using DesafioAVMB.Application.UseCases.CreateEnvelope;
using DesafioAVMB.Application.UseCases.CreateRepository;
using DesafioAVMB.Application.UseCases.CreateSignatory;
using DesafioAVMB.Application.UseCases.GetEnvelope;
using DesafioAVMB.Application.UseCases.GetEnvelopesByRepositorio;
using DesafioAVMB.Application.UseCases.GetFile;
using DesafioAVMB.Application.UseCases.GetRepositories;
using DesafioAVMB.Application.UseCases.SendEnvelope;

using Microsoft.Extensions.DependencyInjection;

namespace DesafioAVMB.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateRepositoryUseCase, CreateRepositoryUseCase>();
        services.AddScoped<ICreateEnvelopeUseCase, CreateEnvelopeUseCase>();
        services.AddScoped<ICreateSignatoryUseCase, CreateSignatoryUseCase>();
        services.AddScoped<ISendEnvelopeUseCase, SendEnvelopeUseCase>();

        services.AddScoped<IGetFileUseCase, GetFileUseCase>();
        services.AddScoped<IGetEnvelopeUseCase, GetEnvelopeUseCase>();
        services.AddScoped<IGetRepositoriesUseCase, GetRepositoriesUseCase>();
        services.AddScoped<IGetEnvelopesByRepositorioUseCase, GetEnvelopesByRepositorioUseCase>();

        return services;
    }
}
