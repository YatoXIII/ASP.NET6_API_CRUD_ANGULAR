using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SamgauTestTask.Models
{
    public class User : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public User()
        {
            Permissions = new List<Permission>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsValidEmail())
            {
                yield return new ValidationResult(
                    "Unavailable email!",
                    new[] { nameof(Email) });
            }
            if (Name.Any(char.IsDigit))
            {
                yield return new ValidationResult(
                   "Unavailable name! Name can't have digits",
                   new[] { nameof(Email) });
            }
        }

        private bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            try
            {
                 Email = Regex.Replace(Email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(Email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}
