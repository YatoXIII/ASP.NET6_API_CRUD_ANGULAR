using System.Linq.Expressions;
using SamgauTestTask.Models;

namespace SamgauTestTask.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FirstOrDefaultWithPermissions(Expression<Func<User, bool>> predicate);
    }
}
