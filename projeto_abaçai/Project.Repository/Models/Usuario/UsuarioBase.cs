using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class UsuarioBase : DomainBase
    {
        public UsuarioBase()
        {

        }

        public int UsuarioId { get; set; } 
        public string Nome { get; set; } 
        public string Apelido { get; set; } 
        public string CPF_CNPJ { get; set; } 
        public string IE_RG { get; set; } 
        public string Telefone { get; set; } 
        public string Celular { get; set; } 
        public string Email { get; set; } 
        public DateTime? UserCreateDate { get; set; } 
        public DateTime? UserAlterDate { get; set; } 
        public int? EnderecoId { get; set; } 
        public bool EhInstituicao { get; set; } 
        public string Foto { get; set; } 


    }
}