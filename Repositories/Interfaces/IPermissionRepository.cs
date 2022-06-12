using System.Linq.Expressions;
using SamgauTestTask.Models;

namespace SamgauTestTask.Repositories.Interfaces
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Permission FirstOrDefaultWithUsers(Expression<Func<Permission, bool>> predicate);

    } 
}
