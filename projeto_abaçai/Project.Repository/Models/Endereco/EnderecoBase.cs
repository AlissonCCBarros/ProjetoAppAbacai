using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class EnderecoBase : DomainBase
    {
        public EnderecoBase()
        {

        }

        public int EnderecoId { get; set; } 
        public string CEP { get; set; } 
        public string Rua { get; set; } 
        public int Numero { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; } 
        public string Estado { get; set; } 


    }
}