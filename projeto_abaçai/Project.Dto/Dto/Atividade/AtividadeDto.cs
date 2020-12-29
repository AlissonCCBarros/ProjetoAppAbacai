using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class AtividadeDto  : DtoBase
	{	
        public int AtividadeId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public int OdsId { get; set; } 
        public int HabilidadeId { get; set; } 
		
	}
}