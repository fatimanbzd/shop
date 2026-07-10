using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Features.Identity.Login
{
    public class LoginResponse
    {
        [Required]
        public required string email { get; set; }
        [Required]
        public required string password { get; set; }
    }
}
