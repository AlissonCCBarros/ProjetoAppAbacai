using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class MatchBase : DomainBase
    {
        public MatchBase()
        {

        }

        public int MatchId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoAtividadeId { get; set; } 
        public bool Aceito { get; set; } 
        public bool Ativo { get; set; } 
        public DateTime DataMatch { get; set; } 
        public DateTime? DataAceito { get; set; } 
        public bool EhNotificado { get; set; } 


    }
}