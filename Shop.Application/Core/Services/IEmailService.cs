using Shop.Application.Core.Models;

namespace Shop.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
