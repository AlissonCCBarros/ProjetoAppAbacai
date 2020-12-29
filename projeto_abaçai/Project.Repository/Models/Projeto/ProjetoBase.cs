using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class ProjetoBase : DomainBase
    {
        public ProjetoBase()
        {

        }

        public int ProjetoId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public DateTime DataInicio { get; set; } 
        public DateTime? DataFim { get; set; } 
        public int EnderecoId { get; set; } 
        public int UsuarioId { get; set; } 
        public string Foto { get; set; } 


    }
}