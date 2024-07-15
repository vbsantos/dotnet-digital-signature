
using DesafioAVMB.Application.UseCases.GetEnvelope;

namespace DesafioAVMB.Application.UseCases.GetEnvelopesByRepositorio;

public class GetEnvelopesByRepositorioUseCaseOutputDto
{
    public required IEnumerable<GetEnvelopeUseCaseOutputDto> Envelopes { get; set; }
}
