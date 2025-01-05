using System.ComponentModel.DataAnnotations;

namespace Trier_3.Dtos
{
    public class ReactionDto
    {
        [Required]
        public string ReactionName { get; set; }
    }
}
