using Restfull_Web_API_with_Repository_and_UW_patterns.Core.IConfiguration;
using Restfull_Web_API_with_Repository_and_UW_patterns.Core.IRepositories;
using Restfull_Web_API_with_Repository_and_UW_patterns.Core.Repositories;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context= context;
            _logger= loggerFactory.CreateLogger("Logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void Dispose()
        {
           _context.Dispose();
        }
    }
}
