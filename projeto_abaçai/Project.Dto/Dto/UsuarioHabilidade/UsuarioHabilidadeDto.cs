using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class UsuarioHabilidadeDto  : DtoBase
	{	
        public int UsuarioHabilidadeId { get; set; } 
        public int UsuarioId { get; set; } 
        public int HabilidadeId { get; set; } 
		
	}
}