using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamgauTestTask.Models;

namespace SamgauTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        UnitOfWork db;
        public PermissionsController(SomeContext someContext)
        {
            db = new UnitOfWork(someContext);
            if (!db.Permissions.Any())
            {
                db.Permissions.Add(new Permission { Code = "0001", Description = "Some permission 1" });
                db.Permissions.Add(new Permission { Code = "0002", Description = "Some permission 2" });
                db.Permissions.Add(new Permission { Code = "0003", Description = "Some permission 3" });
                db.Complete();
            }
        }
        [HttpGet]
        public IEnumerable<Permission> Get()
        {
            return db.Permissions.GetAll();
        }

        [HttpGet("{id}")]
        public Permission Get(int id)
        {
            Permission permission = db.Permissions.FirstOrDefaultWithUsers(x => x.Id == id);
            return permission;
        }

        [HttpPost]
        public IActionResult Post(Permission permission)
        {
            if (ModelState.IsValid)
            {
                if (permission.Id < 0) permission.Id = 0;
                db.Permissions.Add(permission);
                db.Complete();
                return Ok(permission);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Permission permission)
        {
            if (ModelState.IsValid)
            {
                if (permission.Id < 0) permission.Id = 0;
                db.Permissions.Update(permission);
                db.Complete();
                return Ok(permission);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Permission permission = db.Permissions.FirstOrDefault(x => x.Id == id);
            if (permission != null)
            {
                db.Permissions.Remove(permission);
                db.Complete();
            }
            return Ok(permission);
        }
    }
}
