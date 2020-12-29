using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class UsuarioHabilidadeBase : DomainBase
    {
        public UsuarioHabilidadeBase()
        {

        }

        public int UsuarioHabilidadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int HabilidadeId { get; set; } 


    }
}