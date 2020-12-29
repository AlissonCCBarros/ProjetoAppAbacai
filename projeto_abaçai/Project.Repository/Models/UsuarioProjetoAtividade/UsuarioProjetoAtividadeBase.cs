using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class UsuarioProjetoAtividadeBase : DomainBase
    {
        public UsuarioProjetoAtividadeBase()
        {

        }

        public int UsuarioProjetoAtividadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoAtividadeId { get; set; } 
        public int? Avaliacao { get; set; } 


    }
}