using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamgauTestTask.Repositories.Interfaces;

namespace SamgauTestTask.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository Permissions { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}
