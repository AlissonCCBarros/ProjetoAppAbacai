using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class OdsBase : DomainBase
    {
        public OdsBase()
        {

        }

        public int OdsId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public string ImageName { get; set; } 


    }
}