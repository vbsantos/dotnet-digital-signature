using DesafioAVMB.Application.UseCases.CreateEnvelope;
using DesafioAVMB.Application.UseCases.CreateRepository;
using DesafioAVMB.Application.UseCases.CreateSignatory;
using DesafioAVMB.Application.UseCases.GetFile;
using DesafioAVMB.Application.UseCases.SendEnvelope;
using DesafioAVMB.Application.WebService;

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

        return services;
    }
}
