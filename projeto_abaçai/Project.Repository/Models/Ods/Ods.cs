using System.Collections.Generic;

namespace Project.Core.Data.Model
{
    public class Ods : OdsBase
    {
        public virtual ICollection<Atividade> CollectionAtividade { get; set; }
        public Ods()
            : base()
        {

        }

    }
}
