using System;

namespace Project.Core.Filters
{
    public class UsuarioFilterBase : Common.Domain.Base.FilterBase
    {
        public int UsuarioId { get; set; } 
        public string Nome { get; set; } 
        public string Apelido { get; set; } 
        public string CPF_CNPJ { get; set; } 
        public string IE_RG { get; set; } 
        public string Telefone { get; set; } 
        public string Celular { get; set; } 
        public string Email { get; set; } 
        public DateTime? UserCreateDateStart { get; set; } 
        public DateTime? UserCreateDateEnd { get; set; } 
        public DateTime? UserCreateDate { get; set; } 
        public DateTime? UserAlterDateStart { get; set; } 
        public DateTime? UserAlterDateEnd { get; set; } 
        public DateTime? UserAlterDate { get; set; } 
        public int? EnderecoId { get; set; } 
        public bool? EhInstituicao { get; set; } 
        public string Foto { get; set; } 

    }
}
