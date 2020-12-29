namespace Project.Core.Data.Model
{
    public class UsuarioProjetoAtividade : UsuarioProjetoAtividadeBase
    {
        public virtual ProjetoAtividade ProjetoAtividade { get; set; }
        public virtual Usuario Usuario { get; set; }
        public UsuarioProjetoAtividade()
            : base()
        {

        }

    }
}
