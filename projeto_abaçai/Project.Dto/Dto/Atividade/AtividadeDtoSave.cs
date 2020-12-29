using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class AtividadeDtoSave: AtividadeDto
	{
		public int ProjetoId { get; set; }
	}
}