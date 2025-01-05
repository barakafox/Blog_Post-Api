using System.ComponentModel.DataAnnotations;

namespace Trier_3.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Phone]
        public string UserPhone { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public List<Reaction> Reaction { get; set; }
        public List<BlogPost> BlogPost { get; set; }
    }
}
