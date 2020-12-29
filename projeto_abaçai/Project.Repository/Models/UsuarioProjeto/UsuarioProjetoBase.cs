using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class UsuarioProjetoBase : DomainBase
    {
        public UsuarioProjetoBase()
        {

        }

        public int UsuarioProjetoId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoId { get; set; } 


    }
}