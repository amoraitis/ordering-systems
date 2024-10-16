using OrderingSystem.Shared.Common;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public List<Order> Orders { get; set; }
    }
}