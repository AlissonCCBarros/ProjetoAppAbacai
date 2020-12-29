using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class ProjetoAtividadeDto  : DtoBase
	{	
        public int ProjetoAtividadeId { get; set; } 
        public int ProjetoId { get; set; } 
        public int AtividadeId { get; set; } 
		
	}
}