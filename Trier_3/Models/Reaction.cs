using System.ComponentModel.DataAnnotations;

namespace Trier_3.Models
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        [Required]
        public string ReactionName { get; set; }
        public List<User> User { get; set; }
    }
}
