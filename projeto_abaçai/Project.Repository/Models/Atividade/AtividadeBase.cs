using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class AtividadeBase : DomainBase
    {
        public AtividadeBase()
        {

        }

        public int AtividadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public int OdsId { get; set; } 
        public int HabilidadeId { get; set; } 


    }
}