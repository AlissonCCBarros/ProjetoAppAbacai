using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class ProjetoAtividadeBase : DomainBase
    {
        public ProjetoAtividadeBase()
        {

        }

        public int ProjetoAtividadeId { get; set; } 
        public int ProjetoId { get; set; } 
        public int AtividadeId { get; set; } 


    }
}