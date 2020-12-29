using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class ProjetoDto  : DtoBase
	{	
        public int ProjetoId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public DateTime  DataInicio { get; set; } 
        public DateTime? DataFim { get; set; } 
        public int EnderecoId { get; set; } 
        public int UsuarioId { get; set; } 
        public string Foto { get; set; } 
		
	}
}