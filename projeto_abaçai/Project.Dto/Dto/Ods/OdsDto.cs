using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class OdsDto  : DtoBase
	{	
        public int OdsId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public string ImageName { get; set; } 
		
	}
}