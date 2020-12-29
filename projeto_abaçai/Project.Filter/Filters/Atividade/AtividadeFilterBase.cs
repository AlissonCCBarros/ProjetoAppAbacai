using System;

namespace Project.Core.Filters
{
    public class AtividadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int AtividadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public int OdsId { get; set; } 
        public int HabilidadeId { get; set; } 

    }
}
