using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class MatchDto  : DtoBase
	{	
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