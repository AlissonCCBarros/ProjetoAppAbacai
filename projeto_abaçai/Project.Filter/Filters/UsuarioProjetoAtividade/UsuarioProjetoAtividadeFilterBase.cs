using System;

namespace Project.Core.Filters
{
    public class UsuarioProjetoAtividadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int UsuarioProjetoAtividadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoAtividadeId { get; set; } 
        public int? Avaliacao { get; set; } 

    }
}
