using Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Dto.Custom
{
    public class UserDto : DtoBase
    {
        public string Token { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? EhInstituicao { get; set; }
    }
}
