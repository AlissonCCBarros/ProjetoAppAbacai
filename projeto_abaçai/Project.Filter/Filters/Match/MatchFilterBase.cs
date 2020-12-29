using System;

namespace Project.Core.Filters
{
    public class MatchFilterBase : Common.Domain.Base.FilterBase
    {
        public int MatchId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoAtividadeId { get; set; } 
        public bool? Aceito { get; set; } 
        public bool? Ativo { get; set; } 
        public DateTime DataMatchStart { get; set; } 
        public DateTime DataMatchEnd { get; set; } 
        public DateTime DataMatch { get; set; } 
        public DateTime? DataAceitoStart { get; set; } 
        public DateTime? DataAceitoEnd { get; set; } 
        public DateTime? DataAceito { get; set; } 
        public bool? EhNotificado { get; set; } 

    }
}
