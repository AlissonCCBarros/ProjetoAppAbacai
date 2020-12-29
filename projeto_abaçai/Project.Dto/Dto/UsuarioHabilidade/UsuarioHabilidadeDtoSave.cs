using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class UsuarioHabilidadeDtoSave: UsuarioHabilidadeDto
	{
		public ICollection<string> UsuarioHabilidades { get; set; }
	}
}