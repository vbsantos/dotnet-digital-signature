using DesafioAVMB.Domain.Enums;

namespace DesafioAVMB.Application.Common;

public static class ParseEnvelopeStatus
{
    public static string Parse(EEnvelopeStatus status)
    {
        return status switch
        {
            EEnvelopeStatus.EmConstrucao => "Em construção",
            EEnvelopeStatus.AguardandoAssinaturas => "Aguardando Assinaturas",
            EEnvelopeStatus.Concluido => "Concluído",
            EEnvelopeStatus.Arquivado => "Arquivado",
            EEnvelopeStatus.Cancelado => "Cancelado",
            EEnvelopeStatus.Expirado => "Expirado",
            _ => "Desconhecido",
        };
    }
}
