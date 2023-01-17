using Restfull_Web_API_with_Repository_and_UW_patterns.Core.IRepositories;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
