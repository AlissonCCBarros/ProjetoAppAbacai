using System;

namespace Project.Core.Filters
{
    public class UsuarioHabilidadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int UsuarioHabilidadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int HabilidadeId { get; set; } 

    }
}
