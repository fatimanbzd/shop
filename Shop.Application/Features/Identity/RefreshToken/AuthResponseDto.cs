using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Features.Identity.RefreshToken
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
