using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class UsuarioProjetoDto  : DtoBase
	{	
        public int UsuarioProjetoId { get; set; } 
        public int UsuarioId { get; set; } 
        public int ProjetoId { get; set; } 
		
	}
}