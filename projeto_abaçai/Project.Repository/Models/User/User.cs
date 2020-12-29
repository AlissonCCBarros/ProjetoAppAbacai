using Common.Domain.Base;

namespace Project.Core.Data.Model
{
    public class User : DomainBase
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }

    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public string Teste { get; set; }
    }
}