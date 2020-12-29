using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class EnderecoDtoSave: EnderecoDto
	{
		public EnderecoDto Endereco { get; set; }
	}
}