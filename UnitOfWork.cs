using SamgauTestTask.Models;
using SamgauTestTask.Repositories;
using SamgauTestTask.Repositories.Interfaces;
using SamgauTestTask.Interfaces;

namespace SamgauTestTask
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SomeContext _context;

        public UnitOfWork(SomeContext context)
        {
            _context = context;
            Permissions = new PermissionRepository(_context);
            Users = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IPermissionRepository Permissions { get; }
        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
