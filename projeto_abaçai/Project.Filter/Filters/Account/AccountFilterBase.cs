using System;

namespace Project.Core.Filters
{
    public class AccountFilterBase : Common.Domain.Base.FilterBase
    {
        public int AccountId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public bool? Admin { get; set; } 

    }
}
