using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SamgauTestTask.Models;
using SamgauTestTask.Repositories.Interfaces;

namespace SamgauTestTask.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private SomeContext SomeContext => Context as SomeContext;
        public UserRepository(DbContext context) : base(context)
        {
            
        }

        public User FirstOrDefaultWithPermissions(Expression<Func<User, bool>> predicate)
        {
            return SomeContext.Users.Include(p => p.Permissions).FirstOrDefault(predicate);
        }
    }
}
