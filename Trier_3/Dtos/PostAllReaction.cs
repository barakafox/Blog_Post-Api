using System.ComponentModel.DataAnnotations;
using Trier_3.Models;

namespace Trier_3.Dtos
{
    public class PostAllReaction
    {
        [Required]
        public string ReactionName { get; set; }
        public List<UserDto> UserDto { get; set; }
    }
}
