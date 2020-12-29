using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Data.Model
{
    public class Atividade : AtividadeBase
    {
        public virtual Habilidade  Habilidade { get; set; }
        public virtual Ods  Ods { get; set; }

        [NotMapped]
        public int ProjetoId { get; set; }
        public Atividade()
            : base()
        {

        }

    }
}
