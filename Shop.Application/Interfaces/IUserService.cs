using Shop.Application.Models.DTOs.UserDto;
using Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}
