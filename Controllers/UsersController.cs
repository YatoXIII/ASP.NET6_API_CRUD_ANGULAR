using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamgauTestTask.Models;

namespace SamgauTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UnitOfWork db;
        public UsersController(SomeContext someContext)
        {
            db = new UnitOfWork(someContext);
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Ivan", Login = "vini", Email = "vini@a.kz" });
                db.Users.Add(new User { Name = "Petya", Login = "pet", Email = "pet@a.kz" });
                db.Users.Add(new User { Name = "Aslan", Login = "asa", Email = "asa@a.kz" });
                db.Complete();
            }
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.GetAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = db.Users.FirstOrDefaultWithPermissions(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id < 0) user.Id = 0;
                db.Users.Add(user);
                db.Complete();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id < 0) user.Id = 0;
                db.Users.Update(user);
                db.Complete();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.Complete();
            }
            return Ok(user);
        }

    }
}


