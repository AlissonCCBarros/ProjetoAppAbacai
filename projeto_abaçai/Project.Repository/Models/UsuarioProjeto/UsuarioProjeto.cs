using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class UsuarioProjeto : UsuarioProjetoBase
    {
        public Usuario Usuario { get; set; }
        public UsuarioProjeto()
            : base()
        {

        }

    }
}
