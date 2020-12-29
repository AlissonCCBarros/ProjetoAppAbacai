using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class HabilidadeDto  : DtoBase
	{	
        public int HabilidadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
		
	}
}