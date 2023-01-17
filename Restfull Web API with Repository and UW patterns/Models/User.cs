using System.ComponentModel.DataAnnotations;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
