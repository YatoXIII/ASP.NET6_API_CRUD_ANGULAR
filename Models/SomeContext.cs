using Microsoft.EntityFrameworkCore;
using SamgauTestTask.Models;
using System.Configuration;

namespace SamgauTestTask.Models
{
    public class SomeContext : DbContext
    {
        public SomeContext(DbContextOptions<SomeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
    }

}
