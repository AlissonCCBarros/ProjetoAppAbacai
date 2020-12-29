using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class ProjetoAtividade : ProjetoAtividadeBase
    {
        public virtual Atividade Atividade { get; set; }
        public virtual Projeto Projeto { get; set; }
        
        public ICollection<Match> CollectionMatch { get; set; }

        public virtual ICollection<UsuarioProjetoAtividade> CollectionUsuarioProjetoAtividade { get; set; }
        public ProjetoAtividade()
            : base()
        {

        }

    }
}
