using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Data.Model
{
    public class Account : AccountBase
    {
        public Usuario Usuario { get; set; }
        [NotMapped]
        public string Celular { get; set; }
        [NotMapped]
        public string CpfCnpj { get; set; }
        public Account()
            : base()
        {

        }

    }
}
