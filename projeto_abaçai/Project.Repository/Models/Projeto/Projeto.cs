using System.Collections;
using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class Projeto : ProjetoBase
    {
        public virtual Endereco Endereco { get; set; }
        public ICollection<ProjetoAtividade> CollectionProjetoAtividade { get; set; }

        public Projeto()
            : base()
        {

        }

    }
}
