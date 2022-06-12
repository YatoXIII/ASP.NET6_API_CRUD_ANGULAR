using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using SamgauTestTask.Models;
using SamgauTestTask.Repositories.Interfaces;

namespace SamgauTestTask.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository  
    {
        private SomeContext SomeContext => Context as SomeContext;
        public PermissionRepository(DbContext context) : base(context)
        {

        }

        public Permission FirstOrDefaultWithUsers(Expression<Func<Permission, bool>> predicate)
        {
            return SomeContext.Permissions.Include(p => p.Users).FirstOrDefault(predicate);
        }

    }
}
