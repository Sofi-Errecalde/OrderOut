using OrderOut.EF.Models;

namespace OrderOut.DtosOU.Dtos
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        
        public UserLoginResponseDto User { get; set; }
    }
}
