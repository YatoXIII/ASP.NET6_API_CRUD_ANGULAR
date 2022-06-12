using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamgauTestTask.Models;

namespace SamgauTestTask.Controllers
{
    [Route("api/Users/Permissions")]
    [ApiController]
    public class UsersPermissionsController : ControllerBase
    {
        UnitOfWork db;
        public UsersPermissionsController(SomeContext someContext)
        {
            db = new UnitOfWork(someContext);
        }

        [HttpGet("{id}")]
        public User GetWithDetals(int id)
        {
            User user = db.Users.FirstOrDefaultWithPermissions(x => x.Id == id);
            return user;
        }

        [HttpPut]
        public IActionResult UpdatePermissions(User user)
        {
             var currentUser = db.Users.FirstOrDefaultWithPermissions(u => u.Id == user.Id);
             db.Users.Attach(currentUser);

            currentUser.Permissions.Clear();

            foreach (var permission in user.Permissions)
            {
                var currentPermission = db.Permissions.FirstOrDefault(p => p.Id == permission.Id);
                currentUser.Permissions.Add(currentPermission);
            }

            if (ModelState.IsValid)
            {
                db.Complete();
                return Ok(currentUser);
            }

            return BadRequest(ModelState);
        }
    }
}


