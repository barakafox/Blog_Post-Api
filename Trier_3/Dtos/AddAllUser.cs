using System.ComponentModel.DataAnnotations;
using Trier_3.Models;

namespace Trier_3.Dtos
{
    public class AddAllUser
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Phone]
        public string UserPhone { get; set; }
        public int RoleId { get; set; }

        public RoleDto RoleDto { get; set; }
        public List<ReactionDto> ReactionDto { get; set; }
        public List<BlogPostDto> BlogPostDto { get; set; }
    }
}
