using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class UsuarioDtoSave: UsuarioDto
	{
		public EnderecoDtoSave Endereco { get; set; }
		public AccountDto Account { get; set; }
		public ICollection<string> Habilidades { get; set; }
	}
}