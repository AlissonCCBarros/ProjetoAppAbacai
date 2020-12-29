using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class Usuario : UsuarioBase
    {
        public Account Account { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<UsuarioProjetoAtividade> CollectionUsuarioProjetoAtividade { get; set; }
        public Usuario()
            : base()
        {

        }

    }
}
