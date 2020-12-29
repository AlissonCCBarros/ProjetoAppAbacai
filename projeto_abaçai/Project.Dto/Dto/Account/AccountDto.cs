using System;
using Common.Dto;

namespace Project.Core.Dto
{
	public class AccountDto  : DtoBase
	{	
        public int AccountId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public bool Admin { get; set; } 
		
	}
}