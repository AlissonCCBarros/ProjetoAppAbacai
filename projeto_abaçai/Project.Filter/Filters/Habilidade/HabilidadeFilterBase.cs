using System;

namespace Project.Core.Filters
{
    public class HabilidadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int HabilidadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 

    }
}
