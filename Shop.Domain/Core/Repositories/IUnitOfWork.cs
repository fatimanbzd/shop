using Shop.Domain.Core.Models;

namespace Shop.Domain.Core.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        Task SaveChangesAsync();
        Task RollBackChangesAsync();
        IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
