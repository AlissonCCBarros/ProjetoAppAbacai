using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class NotificacaoDto  : DtoBase
	{	
        public int NotificacaoId { get; set; } 
        public string Titulo { get; set; } 
        public string Descricao { get; set; } 
        public int? UsuarioId { get; set; } 
        public bool EhAceito { get; set; } 
        public bool EhNotificado { get; set; } 
		
	}
}