using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Filters
{
    public class ProjetoAtividadeFilter : ProjetoAtividadeFilterBase
    {
        public string NomeProjeto { get; set; }
        public string NomeAtividade { get; set; }
        public string Cidade { get; set; }
        public string Ods { get; set; }
    }
}
