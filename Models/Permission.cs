using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamgauTestTask.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public Permission()
        {
            Users = new List<User>();
        }
    }
}
