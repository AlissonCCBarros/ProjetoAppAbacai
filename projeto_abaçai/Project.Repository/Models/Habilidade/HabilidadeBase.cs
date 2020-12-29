using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class HabilidadeBase : DomainBase
    {
        public HabilidadeBase()
        {

        }

        public int HabilidadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 


    }
}