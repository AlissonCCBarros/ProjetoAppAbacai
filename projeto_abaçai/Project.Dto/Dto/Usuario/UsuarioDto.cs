using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class UsuarioDto  : DtoBase
	{	
        public int UsuarioId { get; set; } 
        public string Nome { get; set; } 
        public string Apelido { get; set; } 
        public string CPF_CNPJ { get; set; } 
        public string IE_RG { get; set; } 
        public string Telefone { get; set; } 
        public string Celular { get; set; } 
        public string Email { get; set; } 
        public int? EnderecoId { get; set; } 
        public bool EhInstituicao { get; set; } 
        public string Foto { get; set; } 
		
	}
}