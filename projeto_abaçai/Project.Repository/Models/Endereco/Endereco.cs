using System.Collections;
using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class Endereco : EnderecoBase
    {
        public ICollection<Usuario> CollectionUsuarioEndereco { get; set; }
        public Endereco()
            : base()
        {

        }

    }
}
