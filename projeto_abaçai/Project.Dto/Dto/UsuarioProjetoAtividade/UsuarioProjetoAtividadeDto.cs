using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class UsuarioProjetoAtividadeDto  : DtoBase
	{	
        public int UsuarioProjetoAtividadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoAtividadeId { get; set; } 
        public int? Avaliacao { get; set; } 
		
	}
}