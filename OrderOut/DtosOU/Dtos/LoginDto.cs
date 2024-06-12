using OrderOut.EF.Models;

namespace OrderOut.DtosOU.Dtos
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        
        public User User { get; set; }
    }
}
