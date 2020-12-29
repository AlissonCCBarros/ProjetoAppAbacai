using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class EnderecoDto  : DtoBase
	{	
        public int EnderecoId { get; set; } 
        public string CEP { get; set; } 
        public string Rua { get; set; } 
        public int Numero { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; } 
        public string Estado { get; set; } 
		
	}
}