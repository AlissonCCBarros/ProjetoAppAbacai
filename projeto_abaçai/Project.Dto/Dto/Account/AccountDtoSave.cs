using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Dto
{
	public class AccountDtoSave: AccountDto
	{
		public string CpfCnpj { get; set; }
		public string Celular { get; set; }
	}
}