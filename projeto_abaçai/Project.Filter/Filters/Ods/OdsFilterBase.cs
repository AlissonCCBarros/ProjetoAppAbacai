using System;

namespace Project.Core.Filters
{
    public class OdsFilterBase : Common.Domain.Base.FilterBase
    {
        public int OdsId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public string ImageName { get; set; } 

    }
}
