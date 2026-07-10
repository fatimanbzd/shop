
using Shop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public sealed class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Salt { get; set; }
        public string? Mobile { get; set; }
        [Required] public UserType UserType { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; set; } = false;
        public User(string email, string salt, string firstName, string lastName, string mobile, UserType userType)
        {
            Email = email;
  
            Salt = salt;
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            UserType = userType;
        }

    }

}
