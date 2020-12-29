using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class ProjetoDtoSave: ProjetoDto
	{
		public EnderecoDtoSave Endereco { get; set; }
		public string Data { get; set; }
	}
}