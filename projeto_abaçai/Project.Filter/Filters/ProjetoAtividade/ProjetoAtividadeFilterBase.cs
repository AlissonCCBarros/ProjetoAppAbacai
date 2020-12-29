using System;

namespace Project.Core.Filters
{
    public class ProjetoAtividadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int ProjetoAtividadeId { get; set; } 
        public int ProjetoId { get; set; } 
        public int AtividadeId { get; set; } 

    }
}
