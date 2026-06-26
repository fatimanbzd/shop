using Shop.Application.Models.DTOs.UserDto;
using Shop.Domain.Entities;
using Shop.Domain.Core.Repositories;
using Shop.Application.Core.Services;
using Shop.Application.Interfaces;

namespace Shop.Application.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public ILoggerService _loggerService;
        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }


        public async Task<IEnumerable<User>> GetAll()
            => await _unitOfWork.Repository<User>().GetAllAsync();
    }
}
