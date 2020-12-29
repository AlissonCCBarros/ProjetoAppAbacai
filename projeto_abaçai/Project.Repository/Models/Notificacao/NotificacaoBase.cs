using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class NotificacaoBase : DomainBase
    {
        public NotificacaoBase()
        {

        }

        public int NotificacaoId { get; set; } 
        public string Titulo { get; set; } 
        public string Descricao { get; set; } 
        public int? UsuarioId { get; set; } 
        public bool EhAceito { get; set; } 
        public bool EhNotificado { get; set; } 


    }
}