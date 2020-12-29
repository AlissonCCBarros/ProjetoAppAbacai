using System;

namespace Project.Core.Filters
{
    public class UsuarioProjetoFilterBase : Common.Domain.Base.FilterBase
    {
        public int UsuarioProjetoId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoId { get; set; } 

    }
}
