using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Data.Model
{
    public class AccountBase : DomainBase
    {
        public AccountBase()
        {

        }

        public int AccountId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public bool Admin { get; set; } 


    }
}