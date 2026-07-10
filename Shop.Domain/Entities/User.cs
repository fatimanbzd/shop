
using Shop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public sealed class User
    {
        private User()
        {

        }
        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public UserType UserType { get; private set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; } = false;

        private User(string email, string firstName, string lastName, string mobile, UserType userType)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            UserType = userType;
        }

        public static User CreateCustomer(
    string firstName,
    string lastName,
    string email,
    string mobile)
        {
            return new User(
                email,
                firstName,
                lastName,
                mobile,
                UserType.Customer);
        }

    }

}
