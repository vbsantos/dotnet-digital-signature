using System.ComponentModel;

namespace DesafioAVMB.Domain.Enums;

public enum EEnvelopeStatus
{
    [Description("Em construção")]
    EmConstrucao = 1,
    [Description("Aguardando Assinaturas")]
    AguardandoAssinaturas,
    [Description("Concluído")]
    Concluido,
    [Description("Arquivado")]
    Arquivado,
    [Description("Cancelado")]
    Cancelado,
    [Description("Expirado")]
    Expirado
}
