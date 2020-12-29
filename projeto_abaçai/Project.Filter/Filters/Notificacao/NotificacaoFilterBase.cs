using System;

namespace Project.Core.Filters
{
    public class NotificacaoFilterBase : Common.Domain.Base.FilterBase
    {
        public int NotificacaoId { get; set; } 
        public string Titulo { get; set; } 
        public string Descricao { get; set; } 
        public int? UsuarioId { get; set; } 
        public bool? EhAceito { get; set; } 
        public bool? EhNotificado { get; set; } 

    }
}
